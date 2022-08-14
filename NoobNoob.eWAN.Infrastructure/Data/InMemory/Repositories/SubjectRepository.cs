using NoobNoob.eWAN.Application.Contracts.Data;
using NoobNoob.eWAN.Application.Interfaces.Repositories;

namespace NoobNoob.eWAN.Infrastructure.Data.InMemory.Repositories;

/// <summary>
/// InMemory implementation of the <see cref="IStudentRepository"/> interface.
/// </summary>
public class SubjectRepository : ISubjectRepository
{
    private readonly List<SubjectDto> _subjects = new List<SubjectDto>();
    
    /// <inheritdoc cref="ISubjectRepository.AddSubject"/>
    public async Task<bool> AddSubject(SubjectDto subject)
    {
        try
        {
            _subjects.Add(subject);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <inheritdoc cref="ISubjectRepository.UpdateSubject"/>
    public async Task<bool> UpdateSubject(SubjectDto subject)
    {
        try
        {
            var index = _subjects.FindIndex(s => s.Id == subject.Id);
            _subjects[index] = subject;
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    /// <inheritdoc cref="ISubjectRepository.DeleteSubject"/>
    public async Task<bool> DeleteSubject(SubjectDto subject)
    {
        try
        {
            _subjects.Remove(subject);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <inheritdoc cref="ISubjectRepository.GetById"/>
    public async Task<SubjectDto?> GetById(Guid id)
        => _subjects.FirstOrDefault(subject => subject.Id == id);

    /// <inheritdoc cref="ISubjectRepository.GetByCode"/>
    public async Task<SubjectDto?> GetByCode(string code)
        => _subjects.FirstOrDefault(subject => subject.Code == code);

    /// <inheritdoc cref="ISubjectRepository.GetByTitle"/>
    public async Task<SubjectDto?> GetByTitle(string title)
        => _subjects.FirstOrDefault(subject => subject.Title == title);
}