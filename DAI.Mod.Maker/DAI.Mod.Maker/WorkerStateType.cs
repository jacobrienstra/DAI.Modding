namespace DAI.Mod.Maker {
    public enum WorkerStateType {
        WorkerState_InitialImport,
        WorkerState_ExportAllEbx,
        WorkerState_SavePatch,
        WorkerState_OpenPatch,
        WorkerState_ImportPatch,
        WorkerState_LoadMap,
        WorkerState_NewPatch
    }
}
