using MedicationControlSystem.src.dtos;
using MedicationControlSystem.src.model;
using MedicationControlSystem.src.repositories;
using MedicationControlSystem.src.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MedicationControlSystem.src.controllers
{

    [ApiController]
    [Route("api/Patient")]
    [Produces("application/json")]
    public class PatientController : ControllerBase
    {
        #region Attribute

        private readonly IPatient _repository;
        private readonly IAuthentication _services;

        #endregion

        #region Constructor

        public PatientController(IPatient repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get user by Name
        /// </summary>
        /// <param name="namePatient">string</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorn patient</response>
        /// <response code="204">Name don't exist</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public async Task<ActionResult> GetAllPatientsAsync([FromQuery] string namePatient)
        {
            List<PatientModel> patient = await _repository.GetAllPatientsAsync(namePatient);

            if (patient.Count < 1) return NoContent();

            return Ok(patient);
        }

        /// <summary>
        /// Get patient by Id
        /// </summary>
        /// <param name="idPatient">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Return user</response>
        /// <response code="404">User don't exist</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("id/{idPatient}")]
        public async Task<ActionResult> GetPatientByIdAsync([FromRoute] int idPatient)
        {
            PatientModel user = await _repository.GetPatientByIdAsync(idPatient);

            if (user == null) return NotFound();

            return Ok(user);
        }


        /// <summary>
        /// Create new patient
        /// </summary>
        /// <param name="patient">NewPatientDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// requisition example:
        ///
        ///     POST /api/Patient
        ///     {
        ///        "name": "Murilo",
        ///        "age": 21,
        ///        "cpf": "49301335476",
        ///        "address": "AddressTest - 123",
        ///        "telephone": "(11) 96543-2356"
        ///        "symptoms": "Dor de cabeça, febre"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Return created patient</response>
        /// <response code="400">request error</response>
        /// <response code="401">E-mail already registered</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PatientModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost("register")]

        public async Task<ActionResult> NewUserAsync([FromBody] NewPatientDTO patient)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                await _services.CreateUserWithoutDuplicateAsync(patient);
                return Created($"api/Patient/name/{patient.Name}", patient);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        /// <summary>
        /// Updated patient
        /// </summary>
        /// <param name="user">UpdatePatientDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// requisition example:
        ///
        ///     PUT /api/User
        ///     {
        ///        "id": 1,    
        ///        "name": "Murilo",
        ///        "age": 21,
        ///        "cpf": "49301335476",
        ///        "address": "AddressTest - 123",
        ///        "telephone": "(11) 96543-2356"
        ///        "symptoms": "Dor de cabeça, febre"
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Return updated patient</response>
        /// <response code="400">requisition error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]

        public async Task<ActionResult> UpdatePatientAsync([FromBody] UpdatePatientDTO patient)
        {
            await _repository.UpdatePatientAsync(patient);
            return Ok(patient);
        }

        /// <summary>
        /// Delete patient by Id
        /// </summary>
        /// <param name="idPatient">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="204">patient deleted</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("delete/{idPatient}")]

        public async Task<ActionResult> DeletePatientAsync([FromRoute] int idPatient)
        {
            await _repository.DeletePatientAsync(idPatient);
            return NoContent();
        }
    }

        #endregion
}

