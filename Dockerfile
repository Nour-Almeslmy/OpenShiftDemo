#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GSM/OpenShiftDemo_Business/OpenShiftDemo_Business.csproj", "GSM/OpenShiftDemo_Business/"]
COPY ["GSM/OpenShiftDemo_Utilities/OpenShiftDemo_Utilities.csproj", "GSM/OpenShiftDemo_Utilities/"]
COPY ["Common/OpenShiftDemo.Common.Business/OpenShiftDemo.Common.Business.csproj", "Common/OpenShiftDemo.Common.Business/"]
RUN dotnet restore "GSM/OpenShiftDemo_Business/OpenShiftDemo_Business.csproj"
COPY . .
WORKDIR "/src/GSM"
RUN dotnet build "OpenShiftDemo_Business/OpenShiftDemo_Business.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenShiftDemo_Business/OpenShiftDemo_Business.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenShiftDemo_Business.dll"]