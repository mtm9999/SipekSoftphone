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
 */

using System.Runtime.InteropServices;
using System.Threading;
using System;
using System.Net;
using System.Net.Sockets;
using Telephony;

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
    private CCallManager Manager
    {
      get { return CCallManager.getInstance(); }
    }
    #endregion

    #region Constructor

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
      string uri = "sip:" + dialedNo + "@" + Manager.Config.getAccount(accountId).HostName;
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
      string uri = "sip:" + number + "@" + Manager.Config.getAccount().HostName;
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
      string destUri = "<sip:" + dest + "@" + Manager.Config.getAccount().HostName + ">";
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

    #region Wrapper functions
    // callback delegates
    delegate int GetConfigData(int cfgId);
    delegate int OnRegStateChanged(int accountId, int regState);
    delegate int OnCallStateChanged(int callId, int stateId);
    delegate int OnCallIncoming(int callId, string number);
    delegate int OnCallHoldConfirm(int callId);
    delegate int OnMessageReceivedCallback(string from, string message);
    delegate int OnBuddyStatusChangedCallback(int buddyId, int status, string statusText);

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
    private static extern string dll_getCodec(int index);
    [DllImport("pjsipDll.dll")]
    private static extern int dll_getNumOfCodecs();
    [DllImport("pjsipDll.dll")]
    private static extern int dll_setCodecPriority(string name, int prio);

    // call API callbacks
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

    #endregion Wrapper functions

    #region Variables

    static OnCallStateChanged csDel = new OnCallStateChanged(onCallStateChanged);
    static OnRegStateChanged rsDel = new OnRegStateChanged(onRegStateChanged);
    static OnCallIncoming ciDel = new OnCallIncoming(onCallIncoming);
    //static GetConfigData gdDel = new GetConfigData(getConfigData);
    static OnCallHoldConfirm chDel = new OnCallHoldConfirm(onCallHoldConfirm);
    static OnMessageReceivedCallback mrdel = new OnMessageReceivedCallback(onMessageReceived);
    static OnBuddyStatusChangedCallback bscdel = new OnBuddyStatusChangedCallback(onBuddyStatusChanged);

    private static CCallManager CallManager
    {
      get { return CCallManager.getInstance(); }
    }

    #endregion Variables

    #region Methods

    public int initialize()
    {
      // register callbacks (delegates)
      onCallIncoming( ciDel );
      onCallStateCallback( csDel );
      onRegStateCallback( rsDel );
      onCallHoldConfirmCallback(chDel);
      onBuddyStatusChangedCallback(bscdel);
      onMessageReceivedCallback(mrdel);

      // Initialize pjsip...
      int status = start();
      return status;
    }

    public int shutdown()
    {
      return dll_shutdown();
    }

    public int start()
    {
      int status = -1;
      
      //int port = CallManager.SipPort;
      int port = 5060;
      status = dll_init(port);
      status |= dll_main();
      return status;
    }

    /////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////
    // Call API
    //
    public int registerAccounts()
    {
      return registerAccounts(false);
    }

    public int registerAccounts(bool renew)
    {
      if (renew == true)
      {
        dll_removeAccounts();
      } 

      for (int i = 0; i < CallManager.Config.NumOfAccounts; i++)
      {
        IAccount acc = CallManager.Config.getAccount(i);

        // reset account state
        CallManager.setAccountState(i, 0);

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
    public int addBuddy(string ident)
    {
      string uri = "sip:" + ident + "@" + CallManager.Config.getAccount().HostName;
      return dll_addBuddy(uri, true);
    }

    public int delBuddy(int buddyId)
    {
      return dll_removeBuddy(buddyId);
    }

    public int sendMessage(string dest, string message)
    {
      string uri = "sip:" + dest + "@" + CallManager.Config.getAccount().HostName;
      return dll_sendMessage(CallManager.Config.DefaultAccountIndex, uri, message);
    }

    public int setStatus(int accId, EUserStatus status)
    {
      return dll_setStatus(accId, (int)status);
    }

    public string getCodec(int index)
    {
      string temp = dll_getCodec(index);
      return temp;
    }

    public int getNoOfCodecs()
    {
      int no = dll_getNumOfCodecs();
      return no;
    }


    public void setCodecPrioroty(string codecname, int priority)
    {
      dll_setCodecPriority(codecname, priority);
    }

    #endregion Methods

    #region Callbacks

    private static int onCallStateChanged(int callId, int callState)
    {
//    PJSIP_INV_STATE_NULL,	    /**< Before INVITE is sent or received  */
//    PJSIP_INV_STATE_CALLING,	    /**< After INVITE is sent		    */
//    PJSIP_INV_STATE_INCOMING,	    /**< After INVITE is received.	    */
//    PJSIP_INV_STATE_EARLY,	    /**< After response with To tag.	    */
//    PJSIP_INV_STATE_CONNECTING,	    /**< After 2xx is sent/received.	    */
//    PJSIP_INV_STATE_CONFIRMED,	    /**< After ACK is sent/received.	    */
//    PJSIP_INV_STATE_DISCONNECTED,   /**< Session is terminated.		    */
      if (callState == 2) return 0;

      CStateMachine sm = CallManager.getCall(callId);
      if (sm == null) return 0;

      switch (callState)
      {
        case 1:
          //sm.getState().onCalling();
          break;
        case 2:
          //sm.getState().incomingCall("4444");
          break;
        case 3:
          sm.getState().onAlerting();
          break;
        case 4:
          sm.getState().onConnect();
          break;
        case 6:
          sm.getState().onReleased();
          break;
      }
      return 1;
    }

    private static int onCallIncoming(int callId, string uri)
    {
      string display  = "";
      string number = "";
      
      // get indices
      int startNum = uri.IndexOf("<sip:");
      int atPos = uri.IndexOf('@');
      // search for number
      if ((startNum > 0)&&(atPos > startNum))
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

      CStateMachine sm = CallManager.createSession(callId, number);
      sm.getState().incomingCall(number, display);
      return 1;
    }


    private static int onRegStateChanged(int accId, int regState)
    {
      CallManager.setAccountState(accId, regState);
      return 1;
    }


    private static int onCallHoldConfirm(int callId)
    {
      CStateMachine sm = CallManager.getCall(callId);
      if (sm != null) sm.getState().onHoldConfirm();
      return 1;
    }

    //////////////////////////////////////////////////////////////////////////////////

    private static int onMessageReceived(string from, string message)
    {
      CallManager.setMessageReceived(from, message);
      return 1;
    }

    private static int onBuddyStatusChanged(int buddyId, int status, string text)
    {
      CallManager.setBuddyState(buddyId, status, text);
      return 1;
    }

    #endregion Callbacks

  }



} // namespace PjsipWrapper
