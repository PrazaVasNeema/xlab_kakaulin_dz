 public abstract class BaseWorkerState
    {
        protected readonly Worker m_worker;
        public BaseWorkerState(Worker worker)
        {
            m_worker = worker;
        }
        public abstract void Update();
        public abstract void Ill();
    }