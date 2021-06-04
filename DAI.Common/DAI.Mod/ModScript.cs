namespace DAI.Mod {
    public interface IModScript {
        void ConstructUI(ModConfigElementsList ConfigElementsList);

        void RunScript();
    }
}
