    public class WorkerChangeFinancialSituationState : BaseWorkerState // Минус - приходится описывать каждое состояние
    {
            public WorkerChangeFinancialSituationState(Worker worker) : base(worker) { }

            public override void Update()
            {
                m_worker.ChangeFinancialSituation();
            }
            public override void Ill()
            {
                if(m_worker.placeIndex != 0)
                {
                    m_worker.ChangeState(WorkerState.Move);
                }
                else
                {
                    m_worker.ChangeFinancialSituation();
                }
            }
    }