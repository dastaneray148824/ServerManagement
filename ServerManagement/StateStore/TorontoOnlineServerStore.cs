namespace ServerManagement.StateStore
{
    public class TorontoOnlineServerStore:Observer
    {
        private int _numServersOnline;

        public int GetNumberServersOnline()
        {
            return _numServersOnline;
        }

        public void SetNumberServersOnline(int number)
        {
            _numServersOnline = number;
            base.BroadcastStateChange();
        }
    }
}
