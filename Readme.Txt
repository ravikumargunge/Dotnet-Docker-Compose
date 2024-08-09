sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Password@1234" -p 1433:1433  --name sqlserverinstance --hostname sqlserverinstance -v SQlDbVol:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04


# Create migrations, Execute this command from DataAccess project.
dotnet ef migrations add InitialCreate --startup-project ../webapi

# Apply migrations, Execute this command from DataAccess project.
dotnet ef database update --startup-project ../webapi

# To remove bin and obj directories from all the folders. Works for Linux based OS.
find . -type d \( -name "bin" -o -name "obj" \) -exec rm -rf {} +

# then commit
git commit -m "Remove bin and obj folders from Git repository"

sudo docker stop sqlserverinstance
sudo docker rm sqlserverinstance

sudo docker stop webapi
sudo docker rm webapi




