namespace PomToolbox.Services.Interfaces
{
    public interface IPokemonTcgApiService
    {
        Task<string> GetPokemonByName(string name);
    }
}