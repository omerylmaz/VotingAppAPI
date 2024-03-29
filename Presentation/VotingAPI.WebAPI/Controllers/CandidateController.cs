﻿using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Abstractions.Storage;
using VotingAPI.Application.Dto.General;
using VotingAPI.Application.Dto.Request.Candidate;
using VotingAPI.Application.Dto.Request.Department;
using VotingAPI.Application.Dto.Request.File;
using VotingAPI.Application.Enums;
using VotingAPI.Application.Repositories.ModelRepos;
//using VotingAPI.Domain.Entities.FileTypes;

namespace VotingAPI.WebAPI.Controllers
{
    [Route("api/candidate")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetCandidateListAsync()
        {
            var response = await _candidateService.GetCandidateListAsync();
            return Ok(response);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCandidateById([FromRoute]int id)
        {
            var response = await _candidateService.GetCandidateByIdAsync(id);
            return Ok(response);
        }

        [HttpGet]
        [Route("filter")]
        public IActionResult GetCandidatesWhere([FromQuery] CandidateFilterRequest filter)
        {
            return Ok();
        }


        [Route("")]
        [Authorize(Roles = "Student")]
        [HttpPost]
        public async Task<IActionResult> AddCandidateAsync(AddCandidateRequest addCandidateRequest)
        {
            var response = await _candidateService.AddCandidateAsync(addCandidateRequest);
            //if (!response.IsSuccessful)
            //    return BadRequest(response);
            return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
        }

        [Route("{userName}/withdraw")]
        [Authorize(Roles = "Candidate")]
        [HttpPatch]
        public async Task<IActionResult> WithdrawCandidateAsync([FromRoute] string userName)
        {
            var response = await _candidateService.WithdrawCandidateAsync(userName);
            //if (!response.IsSuccessful)
            //    return BadRequest(response);
            return Ok(response);
        }

        //[Route("{candidateId}/image/{fileTypeId}")]
        //[HttpGet]
        //public async Task<IActionResult> GetCandidateFileAsync(int candidateId, short fileTypeId)
        //{
        //    var candidateImage = await _candidateService.GetCandidateFileAsync(candidateId, fileTypeId);
        //    //if (!candidateImage.IsSuccessful)
        //    //    return BadRequest(candidateImage);
        //    return Ok(candidateImage);
        //}
        //[Route("{candidateId}/image/{fileType}")]
        //[HttpPost]
        //public async Task<IActionResult> UploadCandidateFileAsync([FromRoute]int candidateId, short fileType)
        //{
        //    AddCandidateFileRequest addFileRequest = new() { CandidateId = candidateId, FileTypeId = (FileTypes)fileType, Files = Request.Form.Files };
        //    var photoResponse = await _candidateService.UploadCandidateFileAsync(addFileRequest);
        //    //if (!photoResponse.IsSuccessful)
        //    //    return BadRequest(photoResponse);
        //    return new ObjectResult(photoResponse) { StatusCode = StatusCodes.Status201Created };
        //}
        //[Route("{candidateId}/image/{fileTypeId}")]
        //[HttpDelete]
        //public async Task<IActionResult> DeleteCandidateProfilePhotoAsync(int candidateId, short fileTypeId)
        //{
        //    var profilePhoto = await _candidateService.DeleteCandidateFileAsync(candidateId, fileTypeId);
        //    //if (!profilePhoto.IsSuccessful)
        //    //    return BadRequest(profilePhoto);
        //    return Ok(profilePhoto);
        //}
    }
}