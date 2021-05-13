namespace DAI.ModMaker
{
	public class WorkerState
	{
		public WorkerStateType Type;

		public object Payload;

		public WorkerState(WorkerStateType InType, object InPayload)
		{
			Type = InType;
			Payload = InPayload;
		}
	}
}
