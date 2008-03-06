/* 
 * Copyright (C) 2007 Sasa Coh <sasacoh@gmail.com>
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 
 * 
 * @see http://pages.google.com/edit/sipekphone/pjsipwrapper
 * 
 */

using System.Runtime.InteropServices;
using System.Threading;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Common;

namespace PjsipWrapper
{

  /// <summary>
  /// 
  /// </summary>
  public class CSipCallProxy : ICallProxyInterface
  {
    #region DLL declarations
    // call API
    [DllImport("pjsipDll.dll")]
    private static extern int dll_makeCall(int accountId, string uri);
    [DllImport("pjsipDll.dll")]
    private static extern int dll_releaseCall(int callId);
    [DllImport("pjsipDll.dll")]
    private static extern int dll_answerCall(int callId, int code);
    [DllImport("pjsipDll.dll")]
    private static extern int dll_holdCall(int callId);
    [DllImport("pjsipDll.dll")]
    private static extern int dll_retrieveCall(int callId);
    [DllImport("pjsipDll.dll")]
    private static extern int dll_xferCall(int callId, string uri);
    [DllImport("pjsipDll.dll")]
    private static extern int dll_xferCallWithReplaces(int callId, int dstSession);
    [DllImport("pjsipDll.dll")]
    private static extern int dll_serviceReq(int callId, int serviceCode, string destUri);
    [DllImport("pjsipDll.dll")]
    private static extern int dll_dialDtmf(int callId, string digits, int mode);
    [DllImport("pjsipDll.dll")]
    private static extern int dll_sendInfo(int callid, string content);

    #endregion

    #region Properties
    private AbstractFactory _factory = new NullFactory();

    public IConfiguratorInterface Config
    {
      get { return _factory.getConfigurator(); }
    }
    #endregion

    #region Constructor

    public CSipCallProxy(AbstractFactory factory)
    {
      _factory = factory;
    }

    #endregion Constructor


    #region Methods

    /// <summary>
    /// Method makeCall creates call session
    /// </summary>
    /// <param name="dialedNo"></param>
    /// <param name="accountId"></param>
    /// <returns>SessionId selected by sip stack</returns>
    public int makeCall(string dialedNo, int accountId)
    {
      if (!_factory.getCommonProxy().IsInitialized) return -1;

      string uri = "sip:" + dialedNo + "@" + Config.getAccount(accountId).HostName;
      int sessionId = dll_makeCall(accountId, uri);
      return sessionId;
    }

    public bool endCall(int sessionId)
    {
      dll_releaseCall(sessionId);
      return true;
    }

    public bool alerted(int sessionId)
    {
      dll_answerCall(sessionId, 180);
      return true;
    }

    public bool acceptCall(int sessionId)
    {
      dll_answerCall(sessionId, 200);
      return true;
    }
    
    public bool holdCall(int sessionId)
    {
      dll_holdCall(sessionId);
      return true;
    }
    
    public bool retrieveCall(int sessionId)
    {
      dll_retrieveCall(sessionId);
      return true;
    }
          
    public bool xferCall(int sessionId, string number)
    {
      string uri = "sip:" + number + "@" + Config.getAccount().HostName;
      dll_xferCall(sessionId, uri);
      return true;
    }
    
    public bool xferCallSession(int sessionId, int session)
    {
      dll_xferCallWithReplaces(sessionId, session);
      return true;
    }

    public bool threePtyCall(int sessionId, int session)
    {
      dll_serviceReq(sessionId, (int)EServiceCodes.SC_3PTY, "");
      return true;
    }
    
    public bool serviceRequest(int sessionId, int code, string dest)
    {
      string destUri = "<sip:" + dest + "@" + Config.getAccount().HostName + ">";
      dll_serviceReq(sessionId, (int)code, destUri);
      return true;
    }

    public bool dialDtmf(int sessionId, string digits, int mode)
    {
      // todo:::check the dtmf mode
      if (mode == 0)
      {
        dll_dialDtmf(sessionId, digits, mode);
      }
      else
      {
        dll_sendInfo(sessionId, digits);
      }
      return true;
    }

    #endregion Methods

  }

  /// <summary>
  /// 
  /// </summary>
  public class CSipCommonProxy : ICommonProxyInterface
  {
    #region Constructor

    private static CSipCommonProxy _instance = null;

    public static CSipCommonProxy GetInstance()
    { 
      if (_instance == null)
      {
        _instance = new CSipCommonProxy();
      }
      return _instance;
    }

    protected CSipCommonProxy()
    {
    }
    #endregion

    #region Properties

    private AbstractFactory _factory = new NullFactory();
    public AbstractFactory Factory
    {
      set { _factory = value; }
    }

    private IConfiguratorInterface Config
    {
      get { return _factory.getConfigurator(); }
    }
    #endregion

    #region Wrapper functions
    // callback delegates
    delegate int GetConfigData(int cfgId);
    delegate int OnRegStateChanged(int accountId, int regState);
    delegate int OnCallStateChanged(int callId, int stateId);
    delegate int OnCallIncoming(int callId, StringBuilder number);
    delegate int OnCallHoldConfirm(int callId);
    delegate int OnMessageReceivedCallback(StringBuilder from, StringBuilder message);
    delegate int OnBuddyStatusChangedCallback(int buddyId, int status, StringBuilder statusText);
    delegate int OnDtmfDigitCallback(int callId, int digit);
    delegate int OnMessageWaitingCallback(int mwi, StringBuilder info);

    [DllImport("pjsipDll.dll")]
    private static extern int dll_init(int listenPort);
    [DllImport("pjsipDll.dll")]
    private static extern int dll_main();
    [DllImport("pjsipDll.dll")]
    private static extern int dll_shutdown();
    [DllImport("pjsipDll.dll")]
    private static extern int dll_registerAccount(string uri, string reguri, string domain, string username, string password);
    [DllImport("pjsipDll.dll")]
    private static extern int dll_addBuddy(string uri, bool subscribe);
    [DllImport("pjsipDll.dll")]
    private static extern int dll_removeBuddy(int buddyId);
    [DllImport("pjsipDll.dll")]
    private static extern int dll_sendMessage(int buddyId, string uri, string message);
    [DllImport("pjsipDll.dll")]
    private static extern int dll_setStatus(int accId, int presence_state);
    [DllImport("pjsipDll.dll")]
    private static extern int dll_removeAccounts();
    [DllImport("pjsipDll.dll")]
    private static extern StringBuilder dll_getCodec(int index);
    [DllImport("pjsipDll.dll")]
    private static extern int dll_getNumOfCodecs();
    [DllImport("pjsipDll.dll")]
    private static extern int dll_setCodecPriority(String name, int prio);

    // Callback function registration declarations 
    // passing delegate to unmanaged code (.dll)
    [DllImport("pjsipDll.dll")]
    private static extern int onCallStateCallback(OnCallStateChanged cb);
    [DllImport("pjsipDll.dll")]
    private static extern int onRegStateCallback(OnRegStateChanged cb);
    [DllImport("pjsipDll.dll")]
    private static extern int onCallIncoming(OnCallIncoming cb);
    [DllImport("pjsipDll.dll")]
    private static extern int getConfigDataCallback(GetConfigData cb);
    [DllImport("pjsipDll.dll")]
    private static extern int onCallHoldConfirmCallback(OnCallHoldConfirm cb);
    [DllImport("pjsipDll.dll")]
    private static extern int onMessageReceivedCallback(OnMessageReceivedCallback cb);
    [DllImport("pjsipDll.dll")]
    private static extern int onBuddyStatusChangedCallback(OnBuddyStatusChangedCallback cb);
    [DllImport("pjsipDll.dll")]
    private static extern int onDtmfDigitCallback(OnDtmfDigitCallback cb);
    [DllImport("pjsipDll.dll")]
    private static extern int onMessageWaitingCallback(OnMessageWaitingCallback cb);

    #endregion Wrapper functions

    #region Variables
    // Static declaration because of CallbackonCollectedDelegate exception!
    static OnCallStateChanged csDel = new OnCallStateChanged(onCallStateChanged);
    static OnRegStateChanged rsDel = new OnRegStateChanged(onRegStateChanged);
    static OnCallIncoming ciDel = new OnCallIncoming(onCallIncoming);
    static OnCallHoldConfirm chDel = new OnCallHoldConfirm(onCallHoldConfirm);
    static OnMessageReceivedCallback mrdel = new OnMessageReceivedCallback(onMessageReceived);
    static OnBuddyStatusChangedCallback bscdel = new OnBuddyStatusChangedCallback(onBuddyStatusChanged);
    static OnDtmfDigitCallback dtdel = new OnDtmfDigitCallback(onDtmfDigitCallback);
    static OnMessageWaitingCallback mwidel = new OnMessageWaitingCallback(onMessageWaitingCallback);


    #endregion Variables

    #region Methods


    public override int initialize()
    {
      // register callbacks (delegates)
      onCallIncoming( ciDel );
      onCallStateCallback( csDel );
      onRegStateCallback( rsDel );
      onCallHoldConfirmCallback(chDel);
      onBuddyStatusChangedCallback(bscdel);
      onMessageReceivedCallback(mrdel);
      onDtmfDigitCallback(dtdel);
      onMessageWaitingCallback(mwidel);

      // Initialize pjsip...
      int status = start();
      // set initialized flag
      IsInitialized = (status == 0) ? true : false;

      return status;
    }


    public int start()
    {
      int status = -1;
      
      int port = Config.SIPPort;
      status = dll_init(port);

      if (status != 0) return status;

      status |= dll_main();
      return status;
    }

    public override int shutdown()
    {
      return dll_shutdown();
    }

    /////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////
    // Call API
    //
    public override int registerAccounts()
    {
      return registerAccounts(false);
    }

    public override int registerAccounts(bool renew)
    {
      if (!IsInitialized) return -1;

      if (renew == true)
      {
        dll_removeAccounts();
      } 

      for (int i = 0; i < Config.NumOfAccounts; i++)
      {
        IAccount acc = Config.getAccount(i);
        // check if accounts available
        if (null == acc) return -1;

        // reset account state
        //CallManager.setAccountState(i, 0);
        BaseAccountStateChanged(i, 0);

        if (acc.Id.Length > 0)
        {
          if (acc.HostName == "0") continue;

          string displayName = acc.DisplayName; 
          // Publish do not work if display name in uri 
          string uri = displayName + "<sip:" + acc.Id + "@" + acc.HostName + ">";
          //string uri = "sip:" + Manager.getId(i) + "@" + Manager.getAddress(i) + "";
          string reguri = "sip:" + acc.HostName; // +":" + CCallManager.getInstance().SipProxyPort;

          string domain = acc.DomainName;
          string username = acc.UserName;
          string password = acc.Password;

          dll_registerAccount(uri, reguri, domain, username, password);

          // todo:::check if accId corresponds to account index!!!
        }
      }
      return 1;
    }

    // Buddy list handling
    public override int addBuddy(string ident)
    {
      string uri = "sip:" + ident + "@" + Config.getAccount().HostName;
      return dll_addBuddy(uri, true);
    }

    public override int delBuddy(int buddyId)
    {
      return dll_removeBuddy(buddyId);
    }

    public override int sendMessage(string dest, string message)
    {
      string uri = "sip:" + dest + "@" + Config.getAccount().HostName;
      return dll_sendMessage(Config.DefaultAccountIndex, uri, message);
    }

    public override int setStatus(int accId, EUserStatus status)
    {
      return dll_setStatus(accId, (int)status);
    }

    public override string getCodec(int index)
    {
      StringBuilder buf = dll_getCodec(index);
      return buf.ToString();
    }

    public override int getNoOfCodecs()
    {
      if (!IsInitialized) return 0;

      int no = dll_getNumOfCodecs();
      return no;
    }


    public override void setCodecPrioroty(string codecname, int priority)
    {
      if (!IsInitialized) return;

      dll_setCodecPriority(codecname, priority);
    }

    #endregion Methods

    #region Callbacks

    /// <summary>
    /// 
    /// </summary>
    /// <param name="callId"></param>
    /// <param name="callState"></param>
    /// <returns></returns>
    private static int onCallStateChanged(int callId, int callState)
    {
      GetInstance().BaseCallStateChanged(callId, callState, "");
      return 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="callId"></param>
    /// <param name="sturi"></param>
    /// <returns></returns>
    private static int onCallIncoming(int callId, StringBuilder sturi)
    {
      string uri = sturi.ToString();
      string display  = "";
      string number = "";
    
      // get indices
      int startNum = uri.IndexOf("<sip:");
      int atPos = uri.IndexOf('@');
      // search for number
      if ((startNum >= 0)&&(atPos > startNum))
      {
        number = uri.Substring(startNum + 5, atPos - startNum - 5);  
      }

      // extract display name if exists
      if (startNum >= 0)
      {
        display = uri.Remove(startNum).Trim();
      }
      else 
      { 
        int semiPos = display.IndexOf(';');
        if (semiPos >= 0)
        {
          display = display.Remove(semiPos);
        }
        else 
        {
          int colPos = display.IndexOf(':');
          if (colPos >= 0)
          {
            display = display.Remove(colPos);
          }
        }

      }
      // invoke callback
      GetInstance().BaseIncomingCall(callId, number, display);
      return 1;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="accId"></param>
    /// <param name="regState"></param>
    /// <returns></returns>
    private static int onRegStateChanged(int accId, int regState)
    {
      GetInstance().Config.getAccount(accId).RegState = regState;
      GetInstance().BaseAccountStateChanged(accId, regState);
      return 1;
    }


    private static int onCallHoldConfirm(int callId)
    {
      //CStateMachine sm = CallManager.getCall(callId);
      //if (sm != null) sm.getState().onHoldConfirm();
      // TODO:::implement proper callback
      GetInstance().BaseCallNotification(callId, ECallNotification.CN_HOLDCONFIRM, "");
      return 1;
    }

    //////////////////////////////////////////////////////////////////////////////////

    private static int onMessageReceived(StringBuilder from, StringBuilder text)
    {
      GetInstance().BaseMessageReceived(from.ToString(), text.ToString());
      return 1;
    }

    private static int onBuddyStatusChanged(int buddyId, int status, StringBuilder text)
    {
      GetInstance().BaseBuddyStatusChanged(buddyId, status, text.ToString());
      return 1;
    }

    private static int onDtmfDigitCallback(int callId, int digit)
    {
      GetInstance().BaseDtmfDigitReceived(callId, digit);
      return 1;
    }

    private static int onMessageWaitingCallback(int mwi, StringBuilder info)
    {
      GetInstance().BaseMessageWaitingIndication(mwi, info.ToString());
      return 1;
    }

    #endregion Callbacks

  }



} // namespace PjsipWrapper
