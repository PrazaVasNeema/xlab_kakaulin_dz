// EarnMoney, Move, BurnMoney

public enum WorkerState
{
    ChangeFinancialSituation, Move
}

public class Worker
{
    private Worker m_worker = new Worker();

    private BasePlace[] place;
    private HomePlace m_targetHomePlace;
    private HomePlace m_targetJobPlace;
    private WorkerState m_state;
    private Dictionary<WorkerState, BaseWorkerState> m_states = new Dictionary<WorkerState, BaseWorkerState>();

    public int placeIndex {get; set;}
    private int finances;
    private float workerWalkingSpeed;
    private float CurrentStateEnterTime;


    public Worker()
    {
        place = new BasePlace[2];
        place[0] = new HomePlace(new Vector2D(0,0,0), -10);
        place[1] = new JobPlace(new Vector2D(0,0,0), 10);
        placeIndex = 0;

        m_states.Add(WorkerState.ChangeFinancialSituation, new WorkerChangeFinancialSituationState(this));
        m_states.Add(WorkerState.Move, new WorkerMoveState(this));

        finances = 0;
        workerWalkingSpeed = 1;
        CurrentStateEnterTime = Time.time;
    }

    public void ChangePlace()
    {
        placeIndex = (placeIndex + 1) % place.Length;
    }
    public void ChangeState(WorkerState state)
    {
        m_state = state;
        CurrentStateEnterTime = Time.time;
    }

    public void ChangeFinancialSituation()
    {
        if(Time.time - CurrentStateEnterTime < 10f)
        {
            finances += Time.deltaTime * place[placeIndex].moneyChangingRate;
        }
        else
        {
            ChangePlace();
            ChangeState(WorkerState.Move);
        }
    }
    public void Move()
    {
        if(Vector2D.Distance(transform.position, place[placeIndex].m_position) > .1f)
        {
            Vector2D.MoveTowards(place[placeIndex].m_position, Time.deltaTime * workerWalkingSpeed);
        }
        else
        {
            ChangeState(WorkerState.ChangeFinancialSituation);
        }
    }
    // public void BurnMoney()
    // {
        
    // }

    public void Update()
    {
        m_states[m_state].Update();
    }
    public void Ill()
    {
        m_states[m_state].Ill();
    }



}