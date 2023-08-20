namespace Web.ChainOfResponsibility.ChainOfResponsibility
{
    public class ProcessHandler : IProcessHandler
    {
        private IProcessHandler _nextProcess;
        public virtual object Handle(object o)
        {
            if (_nextProcess != null)
                return _nextProcess.Handle(o);

            return null;
        }

        public IProcessHandler SetNext(IProcessHandler processHandler)
        {
            _nextProcess = processHandler;
            return _nextProcess;
        }
    }
}
