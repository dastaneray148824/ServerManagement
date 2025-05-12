namespace ServerManagement.StateStore
{
    public class MontrealOnlineServerStore : Observer
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
