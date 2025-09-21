global using System.Reflection;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;
global using System.Security.Cryptography;
global using System.Net.Mail;
global using System.Net;

global using Microsoft.Extensions.Options;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.WebUtilities;
global using Microsoft.EntityFrameworkCore.Diagnostics;

global using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

global using Serilog;

global using HangfireBasicAuthenticationFilter;
global using Hangfire;

global using AutoMapper;
global using AutoMapper.QueryableExtensions;

global using FluentValidation;

global using SellingRentingCarsSystem.API.AutoMapping.Extensions;
global using SellingRentingCarsSystem.API.AutoMapping.Profile;
global using SellingRentingCarsSystem.API;
global using SellingRentingCarsSystem.API.Models;
global using SellingRentingCarsSystem.API.ResultsExtensions;
global using SellingRentingCarsSystem.API.Data;
global using SellingRentingCarsSystem.API.DTOs;
global using SellingRentingCarsSystem.API.Abstractions;
global using SellingRentingCarsSystem.API.Interfaces;
global using SellingRentingCarsSystem.API.Errors;
global using SellingRentingCarsSystem.API.Enums;
global using SellingRentingCarsSystem.API.AutoMapping;
global using SellingRentingCarsSystem.API.UnitOfWork;
global using SellingRentingCarsSystem.API.Implementations;
global using SellingRentingCarsSystem.API.ExceptionHandler;
global using SellingRentingCarsSystem.API.HelpExtensions;
global using SellingRentingCarsSystem.API.Abstractions.Consts;

