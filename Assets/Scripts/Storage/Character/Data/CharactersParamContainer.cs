namespace Storage.Character.Data
{
    public struct CharactersParamContainer
    {
        public CharacterParams BaseParams;
        public CharacterParams CurrentParams;

        public CharactersParamContainer(CharacterParams baseParams)
        {
            BaseParams = baseParams;
            CurrentParams = baseParams;
        }
    }
}
