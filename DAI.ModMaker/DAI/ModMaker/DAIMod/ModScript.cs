namespace DAI.ModMaker.DAIMod
{
	public interface ModScript
	{
		void ConstructUI(ModConfigElementsList ConfigElementsList);

		void RunScript();
	}
}
