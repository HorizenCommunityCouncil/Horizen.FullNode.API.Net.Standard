﻿using System;
using System.Collections.Generic;
using System.Text;
using Horizen.FullNode.API.Net.Standard.RPCInputTypes;
using Horizen.FullNode.API.Net.Standard.RPCReturnTypes;

namespace Horizen.FullNode.API.Net.Standard.RPC
{
    public partial interface IZendRPCWallet
    {
        /*== Wallet ==
        addmultisigaddress nrequired ["key",...] ( "account" )
        backupwallet "destination"
        dumpprivkey "horizenaddress"
        dumpwallet "filename"
        encryptwallet "passphrase"
        getaccount "horizenaddress"
        getaccountaddress "account"
        getaddressesbyaccount "account"
        getbalance ( "account" minconf includeWatchonly )
        getnewaddress ( "account" )
        getrawchangeaddress
        getreceivedbyaccount "account" ( minconf )
        getreceivedbyaddress "horizenaddress" ( minconf )
        gettransaction "txid" ( includeWatchonly )
        getunconfirmedbalance
        getwalletinfo
        importaddress "address" ( "label" rescan )
        importprivkey "horizenprivkey" ( "label" rescan )
        importwallet "filename"
        keypoolrefill ( newsize )
        listaccounts ( minconf includeWatchonly)
        listaddresses
        listaddressgroupings
        listlockunspent
        listreceivedbyaccount ( minconf includeempty includeWatchonly)
        listreceivedbyaddress ( minconf includeempty includeWatchonly)
        listsinceblock ( "blockhash" target-confirmations includeWatchonly)
        listtransactions ( "account" count from includeWatchonly)
        listunspent ( minconf maxconf  ["address",...] )
        lockunspent unlock [{"txid":"txid","vout":n},...]
        move "fromaccount" "toaccount" amount ( minconf "comment" )
        sendfrom "fromaccount" "tohorizenaddress" amount ( minconf "comment" "comment-to" )
        sendmany "fromaccount" {"address":amount,...} ( minconf "comment" ["address",...] )
        sendtoaddress "horizenaddress" amount ( "comment" "comment-to" subtractfeefromamount )
        setaccount "horizenaddress" "account"
        settxfee amount
        signmessage "horizenaddress" "message"
        */
        string AddMultiSigAddress(int nrequired, IList<string> keysobject);
        string BackupWallet(string filename); //filename
        string DumpPrivKey(string t_addr);
        string DumpWallet(string filename);
        bool EncryptWallet(string passphrase);// https://zcash-rpc.github.io/encryptwallet.html
        string GetAccount(string address); //returns null
        string GetAccountAddress(string address = "");
        IList<string> GetAddressesByAccount(string address = "");
        decimal GetBalance(string account = "", int minconf = 1, bool includeWatchOnly = false);
        string GetNewAddress(string account = "");
        string GetRawChangeAddress();
        decimal GetReceivedByAccount(string account = "", int minconf = 1);
        decimal GetReceivedByAddress(string address, int minconf = 1);
        GetTransactionResult GetTransaction(string txid, bool includeWatchOnly = false);
        decimal GetUnconfirmedBalance();
        GetWalletInfoResult GetWalletInfo();
        bool ImportAddress(string address, string label = "", bool rescan = true);
        bool ImportPrivKey(string privkey, string label = "", bool rescan = true);
        bool ImportWallet(string filepath);
        bool KeyPoolRefill(int newsize);
        IList<ListAccountsResult> ListAccounts(int minconf = 1, bool includeWatchOnly = false);
        IList<string> ListAddresses();
        object[][][] ListAddressGroupings(); //[][][0] address, [][][1] balance, [][][2] account
        IList<ListLockUnspentResult> ListLockUnspent();
        IList<ListReceivedByAccountResult> ListReceivedByAccount(int minconf = 1, bool includeEmpty = false,
            bool includeWatchOnly = false);
        IList<ListReceivedByAddressResult> ListReceivedByAddress(int minconf = 1, bool includeEmpty = false,
            bool includeWatchOnly = false);
        ListSinceBlockResult ListSinceBlock(string blockhash = null, int targetCOnfirmations = 1,
            bool includeWatchOnly = false);
        IList<ListTransactionsResult> ListTransactions(string account = "*", int count = 10, int from = 0,
            bool includeWatchOnly = false);
        IList<ListUnspentResult> ListUnspent(int minconf = 1, int maxconf = 9999999, IList<string> addresses = null); // TODO: coincontrol
        bool LockUnspent(bool unlock, IList<LockUnspentInputTransaction> transactions);// TODO: coincontrol
        bool Move(string fromAccount = "", string toAccount = "", decimal amount = decimal.Zero, int minconf = 1,
            string comment = null);//TODO: throw deprecated
        string SendFrom(string fromAccount = "", string toAccount = "", decimal amount = decimal.Zero,
            int minconf = 1,
            string comment = null);
        string SendMany(string address, IList<SendManyInput> outputs, int minconf = 1, string comment = null, IList<string> subtractfeefromamount = null);
        string SendToAddress(string address, decimal amount, string comment, string commentto, bool subtractfeefromamount = false);
        void SetAccount(string address, string account = "");
        bool SetTxFee(decimal amount);
        string SignMessage(string taddr, string message);
    }
}
