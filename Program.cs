﻿using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SnowCatch;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHotKeys2();
builder.Services.AddGamepadList();
builder.Services.AddSpeechRecognition();

await builder.Build().RunAsync();
