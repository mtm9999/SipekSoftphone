using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Runtime.InteropServices;
using Sipek.Common.CallControl;
using Sipek.Sip;
using Sipek.Common;

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
    IVoipProxy _commonProxy = null;
    IConfiguratorInterface _config = new SipekConfigurator();

    #region Constructor
    public ConcreteFactory(MainForm mf)
    {
      _form = mf;
      _commonProxy = CSipCommonProxy.GetInstance();
      CSipCommonProxy.GetInstance().Factory = this;
    }
    #endregion Constructor

    #region AbstractFactory methods
    public ITimer createTimer()
    {
      return new GUITimer(_form);
    }

    public IVoipProxy getCommonProxy()
    {
      return _commonProxy;
    }

    public ICallProxyInterface createCallProxy()
    {
      return new CSipCallProxy(this);
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
      if (!_form.Disposing)
        _form.Invoke(_elapsed, new object[] { sender, e});
    }

    public void Start()
    {
      _guiTimer.Start();
    }

    public void Stop()
    {
      _guiTimer.Stop();
    }

    private int _interval;
    public int Interval
    {
      get { return _interval; }
      set { _interval = value; _guiTimer.Interval = value; }
    }

    private TimerExpiredCallback _elapsed;
    public TimerExpiredCallback Elapsed
    {
      set { 
        _elapsed = value;
      }
    }
  }


  // Accounts
  public class SipekAccount : IAccount
  {
    private int _index = -1;
    
    public SipekAccount(int index)
    {
      _index = index;
    }

    #region Properties

    public string AccountName
    {
      get
      {
        return Properties.Settings.Default.cfgSipAccountNames[_index];
      }
      set
      {
        Properties.Settings.Default.cfgSipAccountNames[_index] = value;
      }
    }

    public string HostName
    {
      get
      {
        return Properties.Settings.Default.cfgSipAccountAddresses[_index];
      }
      set
      {
        Properties.Settings.Default.cfgSipAccountAddresses[_index] = value;
      }
    }

    public string Id
    {
      get
      {
        return Properties.Settings.Default.cfgSipAccountIds[_index];
      }
      set
      {
        Properties.Settings.Default.cfgSipAccountIds[_index] = value;
      }
    }

    public string UserName
    {
      get
      {
        return Properties.Settings.Default.cfgSipAccountUsername[_index];
      }
      set
      {
        Properties.Settings.Default.cfgSipAccountUsername[_index] = value;
      }
    }

    public string Password
    {
      get
      {
        return Properties.Settings.Default.cfgSipAccountPassword[_index];
      }
      set
      {
        Properties.Settings.Default.cfgSipAccountPassword[_index] = value;
      }
    }

    public string DisplayName
    {
      get
      {
        return Properties.Settings.Default.cfgSipAccountDisplayName[_index];
      }
      set
      {
        Properties.Settings.Default.cfgSipAccountDisplayName[_index] = value;
      }
    }

    public string DomainName
    {
      get
      {
        return Properties.Settings.Default.cfgSipAccountDomains[_index];
      }
      set
      {
        Properties.Settings.Default.cfgSipAccountDomains[_index] = value;
      }
    }

    public int Port
    {
      get
      {
        return 5060;
      }
      set
      {
        
      }
    }

    public int RegState
    {
      get 
      {
        short value;
        if (Int16.TryParse(Properties.Settings.Default.cfgSipAccountState[_index], out value))
        {
          return value;
        }
        return 0; 
      }
      set
      {
        Properties.Settings.Default.cfgSipAccountState[_index] = value.ToString();
      }
    }

    public bool ImsEnabled
    {
      get
      {
        short value;
        if (Int16.TryParse(Properties.Settings.Default.cfgSipAccountImsEnabled[_index], out value))
        {
          return value == 1 ? true : false;
        }
        return false;
      }
      set
      {
        Properties.Settings.Default.cfgSipAccountImsEnabled[_index] = (value == true ? "1" : "0");
      }
    }

    #endregion

  }

  /// <summary>
  /// 
  /// </summary>
  public class SipekConfigurator : IConfiguratorInterface
  {
    public bool CFUFlag {
      get { return Properties.Settings.Default.cfgCFUFlag; }
      set { Properties.Settings.Default.cfgCFUFlag = value; }
    }
    public string CFUNumber 
    {
      get { return Properties.Settings.Default.cfgCFUNumber; }
      set { Properties.Settings.Default.cfgCFUNumber = value; }
    }
    public bool CFNRFlag 
    {
      get { return Properties.Settings.Default.cfgCFNRFlag; }
      set { Properties.Settings.Default.cfgCFNRFlag = value; }
    }
    public string CFNRNumber 
    {
      get { return Properties.Settings.Default.cfgCFNRNumber; }
      set { Properties.Settings.Default.cfgCFNRNumber = value; }
    }
    public bool DNDFlag {
      get { return Properties.Settings.Default.cfgDNDFlag; }
      set { Properties.Settings.Default.cfgDNDFlag = value; }
    }
    public bool AAFlag {
      get { return Properties.Settings.Default.cfgAAFlag; }
      set { Properties.Settings.Default.cfgAAFlag = value; }
    }

    public bool CFBFlag
    {
      get { return Properties.Settings.Default.cfgCFBFlag; }
      set { Properties.Settings.Default.cfgCFBFlag = value; }
    }

    public string CFBNumber
    {
      get { return Properties.Settings.Default.cfgCFBNumber; }
      set { Properties.Settings.Default.cfgCFBNumber = value; }
    }

    public int SIPPort
    {
      get { return Properties.Settings.Default.cfgSipPort; }
      set { Properties.Settings.Default.cfgSipPort = value; }
    }

    public int DefaultAccountIndex
    {
      get
      {
        return Properties.Settings.Default.cfgSipAccountDefault;
      }
      set
      {
        Properties.Settings.Default.cfgSipAccountDefault = value;
      }
    }

    public int NumOfAccounts
    {
      get {
        return 5;
      }
      set { }
    }

    public IAccount getAccount(int index)
    {
      return new SipekAccount(index);
    }


    public IAccount getAccount()
    {
      return this.getAccount(DefaultAccountIndex);
    }

    public void Save()
    {
      // save properties
      // do not save account state
      for (int i=0; i<5; i++)
      {
        Properties.Settings.Default.cfgSipAccountState[i] = "0";
      }

      Properties.Settings.Default.Save();
    }

    public List<string> CodecList
    {
      get 
      {
        List<string> codecList = new List<string>();
        foreach (string item in Properties.Settings.Default.cfgCodecList)
        {
          codecList.Add(item);
        }
        return codecList; 
      }
      set 
      {
        Properties.Settings.Default.cfgCodecList.Clear();
        List<string> cl = value;
        foreach (string item in cl)
        {
          Properties.Settings.Default.cfgCodecList.Add(item);
        }
      }
    }
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
