using FluentValidation;
using FluentValidation.Results;
using NoobNoob.eWAN.Application.Interfaces.Repositories;
using NoobNoob.eWAN.Application.Interfaces.Services;
using NoobNoob.eWAN.Application.Mappings;
using NoobNoob.eWAN.Core.Entities;
using NoobNoob.eWAN.Core.ValueObjects;

namespace NoobNoob.eWAN.Application.Services;

/// <summary>
/// Implementation of the <see cref="IUserService"/> interface.
/// </summary>
public class SubjectService : ISubjectService
{
    public SubjectService(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }
    
    private readonly ISubjectRepository _subjectRepository;
    
    /// <inheritdoc cref="ISubjectService.CreateSubject"/>
    public async Task<bool> CreateSubject(Subject subject)
    {
        var results = await Task.WhenAll(
            _subjectRepository.GetByCode(subject.Code),
            _subjectRepository.GetByTitle(subject.Title)
        );

        var existingSubjectWithSameCode = results[0];
        if (existingSubjectWithSameCode is not null)
        {
            var message = $"A subject with the same code ({subject.Code}) already exists";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(Subject), message),
            });
        }
        
        var existingSubjectWithSameTitle = results[1];
        if (existingSubjectWithSameTitle is not null)
        {
            var message = $"A subject with the same title ({subject.Title}) already exists";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(Subject), message),
            });
        }

        var subjectDto = subject.ToSubjectDto();
        return await _subjectRepository.AddSubject(subjectDto);
    }
    
    /// <inheritdoc cref="ISubjectService.UpdateSubject"/>
    public async Task<bool> UpdateSubject(Subject subject)
    {
        var subjectDto = subject.ToSubjectDto();
        return await _subjectRepository.UpdateSubject(subjectDto);
    }

    /// <inheritdoc cref="ISubjectService.DeleteSubject"/>
    public async Task<bool> DeleteSubject(Subject subject)
    {
        var subjectDto = subject.ToSubjectDto();
        return await _subjectRepository.DeleteSubject(subjectDto);
    }

    /// <inheritdoc cref="ISubjectService.GetSubjectById"/>
    public async Task<Subject?> GetSubjectById(SubjectId id)
    {
        var subjectDto = await _subjectRepository.GetById(id.Value);
        return subjectDto?.ToSubject();
    }

    /// <inheritdoc cref="ISubjectService.GetSubjectByCode"/>
    public async Task<Subject?> GetSubjectByCode(string code)
    {
        var subjectDto = await _subjectRepository.GetByCode(code);
        return subjectDto?.ToSubject();
    }

    /// <inheritdoc cref="ISubjectService.GetSubjectByTitle"/>
    public async Task<Subject?> GetSubjectByTitle(string title)
    {
        var subjectDto = await _subjectRepository.GetByTitle(title);
        return subjectDto?.ToSubject();
    }
    
    /// <inheritdoc cref="ISubjectService.GetSubjectsByTitle"/>
    public async Task<List<Subject>> GetSubjectsByTitle(string title)
    {
        return new List<Subject>();
    }
}