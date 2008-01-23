using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Runtime.InteropServices;
using Telephony;

namespace Sipek
{
  /// <summary>
  /// ConcreteFactory 
  /// Implementation of AbstractFactory. 
  /// </summary>
  public class ConcreteFactory : AbstractFactory
  {
    MainForm _form; // reference to MainForm to provide timer context
    IMediaProxyInterface _mediaProxy = new CMediaPlayerProxy();
    ICallLogInterface _callLogger = new CCallLog();
    ICommonProxyInterface _commonProxy = new CSipCommonProxy();
    IConfiguratorInterface _config = new SipekConfigurator();

    #region Constructor
    public ConcreteFactory(MainForm mf)
    {
      _form = mf;
    }
    #endregion Constructor

    #region AbstractFactory methods
    public ITimer createTimer()
    {
      return new GUITimer(_form);
    }

    public ICommonProxyInterface getCommonProxy()
    {
      return _commonProxy;
    }

    public ICallProxyInterface createCallProxy()
    {
      return new CSipCallProxy();
    }

    public IConfiguratorInterface getConfigurator()
    {
      return _config;
    }

    // getters
    public IMediaProxyInterface getMediaProxy()
    {
      return _mediaProxy;
    }

    public ICallLogInterface getCallLogger()
    {
      return _callLogger;
    }
    #endregion
  }

  #region Concrete implementations

  public class GUITimer : ITimer
  {
    Timer _guiTimer;
    MainForm _form;


    public GUITimer(MainForm mf)
    {
      _form = mf;
      _guiTimer = new Timer();
      if (this.Interval > 0) _guiTimer.Interval = this.Interval;
      _guiTimer.Interval = 100;
      _guiTimer.Enabled = true;
      _guiTimer.Elapsed += new ElapsedEventHandler(_guiTimer_Tick);
    }

    void _guiTimer_Tick(object sender, EventArgs e)
    {
      _guiTimer.Stop();
      //_elapsed(sender, e);
      // Synchronize thread with GUI because SIP stack works with GUI thread only
      _form.Invoke(_elapsed, new object[] { sender, e});
    }

    public override void Start()
    {
      _guiTimer.Start();
    }

    public override void Stop()
    {
      _guiTimer.Stop();
    }

    private int _interval;
    public override int Interval
    {
      get { return _interval; }
      set { _interval = value; _guiTimer.Interval = value; }
    }

    private TimerExpiredCallback _elapsed;
    public override TimerExpiredCallback Elapsed
    {
      set { 
        _elapsed = value;
      }
    }
  }

  /// <summary>
  /// 
  /// </summary>
  public class SipekConfigurator : IConfiguratorInterface
  {
    public override bool CFUFlag { get { return CSettings.CFU; } }
    public override string CFUNumber { get { return CSettings.CFUNumber; } }
    public override bool CFNRFlag { get { return CSettings.CFNR; } }
    public override string CFNRNumber { get { return CSettings.CFNRNumber; } }
    public override bool DNDFlag { get { return CSettings.DND; } }
    public override bool AAFlag { get { return CSettings.AA; } }
    public override int SipPort { get { return 5060; } }
  }


  //////////////////////////////////////////////////////
  // Media proxy
  // internal class
  public class CMediaPlayerProxy : IMediaProxyInterface
  {
    #region DLL declarations
    [DllImport("WinMM.dll")]
    public static extern bool PlaySound(string fname, int Mod, int flag);

    // these are the SoundFlags we are using here, check mmsystem.h for more
    public int SND_ASYNC = 0x0001; // play asynchronously
    public int SND_FILENAME = 0x00020000; // use file name
    public int SND_PURGE = 0x0040; // purge non-static events
    public int SND_LOOP = 0x0008;  // loop the sound until next sndPlaySound 

    #endregion

    #region Methods

    public int playTone(ETones toneId)
    {
      string fname;
      int SoundFlags = SND_FILENAME | SND_ASYNC | SND_LOOP;

      switch (toneId)
      {
        case ETones.EToneDial:
          fname = "sounds\\dial.wav";
          break;
        case ETones.EToneCongestion:
          fname = "sounds\\congestion.wav";
          break;
        case ETones.EToneRingback:
          fname = "sounds\\ringback.wav";
          break;
        case ETones.EToneRing:
          fname = "sounds\\ring.wav";
          break;
        default:
          fname = "";
          break;
      }

      PlaySound(fname, 0, SoundFlags);
      return 1;
    }

    public int stopTone()
    {
      PlaySound(null, 0, SND_PURGE);
      return 1;
    }
    #endregion

  }

  #endregion Concrete Implementations

}
