using FluentValidation;
using FluentValidation.Results;
using NoobNoob.eWAN.Application.Interfaces.Repositories;
using NoobNoob.eWAN.Application.Interfaces.Services;
using NoobNoob.eWAN.Application.Mappings;
using NoobNoob.eWAN.Core.Entities;
using NoobNoob.eWAN.Core.ValueObjects;

namespace NoobNoob.eWAN.Application.Services;

/// <summary>
/// Implementation of the <see cref="ISubjectService"/> interface.
/// </summary>
public class SubjectService : ISubjectService
{
    public SubjectService(ISubjectRepository subjectRepository, IUnitOfWork unitOfWork)
    {
        _subjectRepository = subjectRepository;
        _unitOfWork = unitOfWork;
    }
    
    private readonly ISubjectRepository _subjectRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    /// <inheritdoc cref="ISubjectService.CreateSubject"/>
    public async Task<bool> CreateSubject(Subject subject, CancellationToken cancellationToken = default(CancellationToken))
    {
        var existingSubjectWithSameCode = await _subjectRepository.GetByCodeAsync(subject.Code, cancellationToken);
        if (existingSubjectWithSameCode is not null)
        {
            var message = $"A subject with the same code ({subject.Code}) already exists";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(Subject), message),
            });
        }
        
        var existingSubjectWithSameTitle = await _subjectRepository.GetByTitleAsync(subject.Title, cancellationToken);
        if (existingSubjectWithSameTitle is not null)
        {
            var message = $"A subject with the same title ({subject.Title}) already exists";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(Subject), message),
            });
        }

        var subjectDto = subject.ToSubjectDto();
        
        var result = await _subjectRepository.AddSubjectAsync(subjectDto, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return result;
    }
    
    /// <inheritdoc cref="ISubjectService.UpdateSubject"/>
    public async Task<bool> UpdateSubject(Subject subject, CancellationToken cancellationToken = default(CancellationToken))
    {
        var subjectDto = subject.ToSubjectDto();
        
        var result = await _subjectRepository.UpdateSubjectAsync(subjectDto, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return result;
    }

    /// <inheritdoc cref="ISubjectService.DeleteSubject"/>
    public async Task<bool> DeleteSubject(Subject subject, CancellationToken cancellationToken = default(CancellationToken))
    {
        var subjectDto = subject.ToSubjectDto();
        
        var result = await _subjectRepository.DeleteSubjectAsync(subjectDto, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result;
    }

    /// <inheritdoc cref="ISubjectService.GetSubjectById"/>
    public async Task<Subject?> GetSubjectById(SubjectId id, CancellationToken cancellationToken = default(CancellationToken))
    {
        var subjectDto = await _subjectRepository.GetByIdAsync(id.Value, cancellationToken);
        return subjectDto?.ToSubject();
    }

    /// <inheritdoc cref="ISubjectService.GetSubjectByCode"/>
    public async Task<Subject?> GetSubjectByCode(string code, CancellationToken cancellationToken = default(CancellationToken))
    {
        var subjectDto = await _subjectRepository.GetByCodeAsync(code, cancellationToken);
        return subjectDto?.ToSubject();
    }

    /// <inheritdoc cref="ISubjectService.GetSubjectByTitle"/>
    public async Task<Subject?> GetSubjectByTitle(string title, CancellationToken cancellationToken = default(CancellationToken))
    {
        var subjectDto = await _subjectRepository.GetByTitleAsync(title, cancellationToken);
        return subjectDto?.ToSubject();
    }
}