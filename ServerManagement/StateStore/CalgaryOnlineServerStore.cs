namespace ServerManagement.StateStore
{
    public class CalgaryOnlineServerStore:Observer
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
