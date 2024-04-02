using API.Dtos;
using API.Dtos.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class PatientController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PatientController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Patient>>> Get()
    {
        var Patients = await _unitOfWork.Patients.GetAllAsync();
        return _mapper.Map<List<Patient>>(Patients);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Patient>>> GetByIdAsync(int id)
    {
        var Patients = await _unitOfWork.Patients.GetByIdAsync(id);
        return Ok(Patients);
    }

    [HttpGet]
    [ApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<Patient>>> Get([FromQuery] Params PatientParams)
    {
        var (totalRegistros, registros) = await _unitOfWork.Patients.GetAllAsync(PatientParams.PageIndex,PatientParams.PageSize,PatientParams.Search);
        var listaProv = _mapper.Map<List<Patient>>(registros);
        return new Pager<Patient>(listaProv,totalRegistros,PatientParams.PageIndex,PatientParams.PageSize,PatientParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize(Roles = "Empleado, Administrador, Gerente")]
    public async Task<ActionResult<string>> Post(Patient Patient)
    {
         if (Patient == null)
        {
            return BadRequest("Patient can´t be null!");
        }
        _unitOfWork.Patients.Add(Patient);
        await _unitOfWork.SaveAsync();
       
        return "Patient have been successfully created";
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Patient>> Put(int id,[FromBody] Patient patient)
{
    Patient patientExist = await _unitOfWork.Patients.GetByIdAsync(id);


    if (patientExist == null)
    {
        return NotFound();
    }
    _mapper.Map(patient, patientExist);
    _unitOfWork.Patients.Update(patient);
    await _unitOfWork.SaveAsync();

    return patientExist;
}


    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
   
    public async Task<IActionResult> Delete(int id)
    {
        var Patient = await _unitOfWork.Patients.GetByIdAsync(id);
        if (Patient == null)
        {
            return NotFound($"Patient {Patient.Id} haven´t been found");
        }
        _unitOfWork.Patients.Remove(Patient);
        await _unitOfWork.SaveAsync();
        return Ok(new { message = $"Patient {Patient.Id} has been successfully removed" });
    }
}