namespace WebApplication6
{
    public class SupaBaseContext
    {
        public SupaBaseContext()
        {
        }

        public async Task<List<User>> GetUsers(Supabase.Client _supabaseClient)
        {
            var result = await _supabaseClient.From<User>().Get();
            return result.Models;
        }

        public async Task<User> AddUser(Supabase.Client _supabaseClient, User user)
        {
            var result = await _supabaseClient.From<User>().Insert(user).Execute();
            return result.Models.Count > 0 ? result.Models[0] : null;
        }

        public async Task<bool> DeleteUser(Supabase.Client _supabaseClient, int userId)
        {
            var result = await _supabaseClient.From<User>().Delete().Match(new { id = userId }).Execute();
            return result.Models.Count > 0;
        }

        public async Task<User> UpdateUser(Supabase.Client _supabaseClient, User user)
        {
            var result = await _supabaseClient.From<User>().Update(user).Match(new { id = user.Id }).Execute();
            return result.Models.Count > 0 ? result.Models[0] : null;
        }

        public async Task<List<City>> GetCities(SupaBaseContext.Client _supabaseClient)
        { 
            var result = await _supabaseClient.From<City>().Get();
            return result.Models;
        }

        public async Task<User> AddCity(Supabase.Client _supabaseClient, City city)
        {
            var result = await _supabaseClient.From<City>().Insert(city).Execute();
            return result.Models.Count > 0 ? result.Models[0] : null;
        }

        public async Task<bool> DeleteCity(Supabase.Client _supabaseClient, int cityId)
        {
            var result = await _supabaseClient.From<City>().Delete().Match(new { id = cityId }).Execute();
            return result.Models.Count > 0;
        }

        public async Task<City> UpdateCity(SupaBase.Client _supabaseClient, City city)
        { 
            var result 
        
        }
    }
}
