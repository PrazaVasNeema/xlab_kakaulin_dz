    public class WorkerChangeFinancialSituationState : BaseWorkerState // Минус - приходится описывать каждое состояние
    {
            public WorkerChangeFinancialSituationState(Worker worker) : base(worker) { }

            public override void Update()
            {
                m_worker.ChangeFinancialSituation();
            }
            public override void Ill()
            {
                m_worker.ChangeState(WorkerState.Move);
            }
    }