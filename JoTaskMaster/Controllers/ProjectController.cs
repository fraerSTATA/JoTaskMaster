﻿using FluentValidation;
using JoTaskMaster.Application.Exceptions.RequestExceptions;
using JoTaskMaster.Application.Features.Projects.Commands.CreateCommand;
using JoTaskMaster.Application.Features.Projects.Commands.DeleteCommand;
using JoTaskMaster.Application.Features.Projects.DTO;
using JoTaskMaster.Application.Features.Projects.Queries.GetAllProjects;
using JoTaskMaster.Application.Features.Projects.Queries.GetProjectById;
using JoTaskMaster.Application.Features.Projects.Queries.GetProjectByManager;
using JoTaskMaster.Application.Features.Projects.Queries.GetProjectByName;
using JoTaskMaster.Application.Features.Projects.Queries.GetProjectByStatus;
using JoTaskMaster.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JoTaskMaster.Api.Controllers
{
    public class ProjectController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectController(IMediator mediator) => _mediator = mediator;

        #region Get methods


        /// <summary>
        /// Get all projects
        /// </summary>
        /// <response code="200">Returns List of project dto</response>
        /// <response code="404">Projects not found</response>
        [HttpGet("")]
        public async Task<ActionResult<Result<List<ProjectDTO>>>> GetAllProjects()
        {
            return await _mediator.Send(new GetAllProjectsQuery());
        }


        /// <summary>
        /// Get project by id
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <response code="200">Returns List project dto</response>
        /// <response code="404">Projects not found</response>
        [HttpGet("{projectId:int}")]
        public async Task<ActionResult<Result<ProjectDTO>>> GetProjectById(int projectId)
        {
            return await _mediator.Send(new GetProjectByIdQuery(projectId));
        }

        /// <summary>
        /// Get all projects created by user
        /// </summary>
        /// <param name="userId">User id</param>
        /// <response code="200">Returns List project dto</response>
        /// <response code="404">Projects not found</response>
        [HttpGet("/user/{userId:int}")]
        public async Task<ActionResult<Result<List<ProjectDTO>>>> GetProjectByUser(int userId)
        {
            return await _mediator.Send(new GetProjectByUserQuery(userId));
        }
        
        /// <summary>
        /// Get project by project name
        /// </summary>
        /// <param name="projectName">Project name</param>
        /// <response code="200">Returns List project dto</response>
        /// <response code="404">Projects not found</response>
        [HttpGet("{projectName}")]
        public async Task<ActionResult<Result<ProjectDTO>>> GetProjectByName(string projectName)
        {
            return await _mediator.Send(new GetProjectByNameQuery(projectName));
        }

        /// <summary>
        /// Get projects by status
        /// </summary>
        /// <param name="statusId">Status id</param>
        /// <response code="200">Returns List project dto</response>
        /// <response code="404">Projects not found</response>
        [HttpGet("/status/{statusId:int}")]
        public async Task<ActionResult<Result<List<ProjectDTO>>>> GetProjectByStatus(int statusId)
        {
            return await _mediator.Send(new GetProjectByStatusQuery(statusId));
        }
        #endregion

        #region Post methods

        /// <summary>
        /// Create Project
        /// </summary>
        /// <param name="command">Create project command which includes require parametres</param>
        /// <response code="200">Project Created</response>
        /// <response code="400">Bad request</response>
        [HttpPost("")]
        public async Task<ActionResult<Result<int>>> CreateProject([FromBody] CreateProjectCommand command)
        {
                return await _mediator.Send(command);
        }
        #endregion

        #region Delete methods

        /// <summary>
        /// DeleteProject
        /// </summary>
        /// <param name="command">Command which inludes require parametres</param>
        /// <response code="200">Project Deleted</response>
        /// <response code="404">Project not found</response>
        [HttpDelete("")]
        public async Task<ActionResult<Result<int>>> DeleteProject([FromBody] DeleteProjectCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion

        #region Put methods
        #endregion


    }
}
