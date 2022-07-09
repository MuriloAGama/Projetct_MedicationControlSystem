using MedicationControlSystem.src.dtos;
using MedicationControlSystem.src.model;
using MedicationControlSystem.src.repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MedicationControlSystem.src.utils.Utility;

namespace MedicationControlSystem.src.controllers
{
    [ApiController]
    [Route("api/Medication")]
    [Produces("application/json")]
    public class MedicationController : ControllerBase
    {
        #region Attribute

        private readonly IMedication _repository;

        #endregion

        #region Constructor

        public MedicationController(IMedication repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get all Medications
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Returns all products</response>
        /// <response code="204">No content</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicationModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
       
        public async Task<ActionResult> GetAllMedicationAsync()
        {
            List<MedicationModel> list = await _repository.GetAllMedicationAsync(RemedyType.Default);

            if (list.Count == 1) return NoContent();
            return Ok(list);
        }

        /// <summary>
        /// Get Medication By Id
        /// </summary>
        ///<returns>ActionResult</returns>
        /// <param name="idMedication">int</param>
        /// <response code="200">Return the Product</response>
        /// <response code="404">Product not found</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicationModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("id/{idMedication}")]
        public async Task<ActionResult> GetMedicationByIdAsync([FromRoute] int idMedication)
        {
            MedicationModel stock = await _repository.GetMedicationByIdAsync(idMedication);
            if (stock == null) return NotFound();
            return Ok(stock);
        }

        /// <summary>
        /// Create a new medication
        /// </summary>
        /// <param name="medication">MedicationDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Medication
        ///     {
        ///        "RemedyName": "DorFlex"
        ///        "RemedyType": "Similar",
        ///        "provider": "ANVISA",
        ///        "description": "Indicado para dor de cabeça",
        ///    
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created medication</response>
        /// <response code="400">Error in request</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MedicationModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("register")]
        public async Task<ActionResult> NewProductAsync([FromBody] NewMedicationDTO medication)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repository.NewMedicationAsync(medication);

            return Created($"api/Medication/name/{medication.RemedyName}", medication);
        }

        /// <summary>
        /// Update a medication
        /// </summary>
        /// <param name="medication">UpdateMedicationDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Medication
        ///     {
        ///        "id": 1,
        ///        "RemedyName": "DorFlex"
        ///        "RemedyType": "Similar",
        ///        "provider": "ANVISA",
        ///        "description": "Indicado para dor de cabeça",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">medication updated</response>
        /// <response code="400">Error in request</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<ActionResult> UpdateMedicationAsync([FromBody] UpdateMedicationDTO medication)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _repository.UpdateMedicationAsync(medication);
            return Ok(medication);
        }

        /// <summary>
        /// Delete a product by id
        /// </summary>
        /// <param name="idMedication">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="204">Ok, but no content</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("delete/{idMedication}")]
        public async Task<ActionResult> DeleteMedicationAsync([FromRoute] int idMedication)
        {
            await _repository.DeleteMedicationAsync(idMedication);
            return NoContent();
        }

    }
    #endregion
}
