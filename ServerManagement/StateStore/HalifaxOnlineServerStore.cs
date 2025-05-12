namespace ServerManagement.StateStore
{
    public class HalifaxOnlineServerStore:Observer
    {
        private int _numserversOnline;

        public int GetNumberServersOnline()
        {
            return _numserversOnline;
        }
        public void SetNumberServersOnline(int number)
        {
            _numserversOnline = number;
            base.BroadcastStateChange();
        }
    }
}

