using UbudKusCoin.P2P;

namespace UbudKusCoin.Services
{
    public static class ServicePool
    {

        public static MintingService MintingService { set; get; }

        public static DbService DbService { set; get; }

        public static FacadeService FacadeService { set; get; }

        public static EventService EventService { set; get; }

        public static WalletService WalletService { set; get; }
        public static P2PService P2PService { set; get; }

        public static void Add(
                  WalletService wallet,
                  DbService db,
                  FacadeService facade,
                  MintingService minter,
                  P2PService p2p,
                  EventService evtserv)
        {
            WalletService = wallet;
            DbService = db;
            FacadeService = facade;
            MintingService = minter;
            EventService = evtserv;
            P2PService = p2p;
        }
        public static void Start()
        {
            WalletService.Start();
            DbService.Start();
            FacadeService.start();
            MintingService.Start();
            P2PService.Start();
            EventService.Start();
        }

        public static void Stop()
        {
            //stop when application exit
            DbService.Stop();
        }


    }
}
