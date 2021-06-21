namespace DAI.Mod {
    public interface ModScript {
        void ConstructUI(ModConfigElementsList ConfigElementsList);

        void RunScript();
    }
}
