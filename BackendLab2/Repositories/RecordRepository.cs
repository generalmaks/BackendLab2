using BackendLab2.Database;
using BackendLab2.Models;

namespace BackendLab2.Repositories;

public class RecordRepository
{
    public Task<Record> GetRecord(int id)
    {
        var record = DatabaseSubstitute.Records.FirstOrDefault(r => r.Id == id);
        return Task.FromResult(record)!;
    }

    public Task DeleteRecord(int id)
    {
        var index = DatabaseSubstitute.Records.FindIndex(r => r.Id == id);
        DatabaseSubstitute.Records.RemoveAt(index);
        return Task.CompletedTask;
    }

    public Task CreateRecord(Record record)
    {
        DatabaseSubstitute.Records.Add(record);
        return Task.CompletedTask;
    }

    public Task<List<Record>> ListRecord(int? userId, int? categoryId)
    {
        if (!userId.HasValue && !categoryId.HasValue)
            throw new Exception("You must provide at least userId or categoryId.");
        
        var records = DatabaseSubstitute.Records.AsQueryable();

        if (userId.HasValue)
            records = records.Where(r => r.UserId == userId.Value);

        if (categoryId.HasValue)
            records = records.Where(r => r.CategoryId == categoryId.Value);

        return Task.FromResult(records.ToList());
    }
}