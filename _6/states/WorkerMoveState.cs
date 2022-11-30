    public class WorkerMoveState : BaseWorkerState // Минус - приходится описывать каждое состояние
    {
            public WorkerMoveState(Worker worker) : base(worker) { }

            public override void Update()
            {
                m_worker.Move();
            }
            public override void Ill()
            {
                m_worker.placeIndex = 0;
                m_worker.Move();
            }
    }