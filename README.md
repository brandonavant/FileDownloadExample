# FileDownloadExample

Demonstration of how to retrieve individual files from a 3rd party service and serve them back in an HTTP response as a .zip file.

# Prerequisites

- Ensure that [Docker Desktop](https://www.docker.com/get-started) is installed.
- Ensure that the [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)  is installed.

# How Does It Work?

There are two applications within the solution:

- ThirdPartyFileHost - This application mimics a blackbox third party API (that cannot be modified), which provides a single endpoint with which an HTTP call get request a file download for a single file. This application reads an on-disk file into memory and sends it back via the HTTP response to the client.
- FileRetrieverService - This application is meant to be the primary backend for whatever client application we are building. The front-end will provide a means by which the user can select multiple file ids which they wish to download (e.g. grid with checkboxes). The front-end then posts the HTTP request containing the file ids (via a JSON-serialized HTTP body). The back-end (FileRetrieverService) then makes a call to the black box API for each of the individual files that we wish to download. It adds each of the files to a single `.zip` file and sends it back to the front-end application in the HTTP response.

# How To Run

1. Ensure that the aforementioned [prerequisites](#prerequisites) are met.
2. Clone this repository into your favorite Git repo destination directory.
3. Open your favorite terminal tool (e.g. PowerShell, bash, zsh, etc.).
4. Navigate into the root directory of this repository; where the `docker-compose.yml` file resides.
5. Run the command `docker compose up`.
6. Wait until you see logging from both services, which will indicate that the services are up and running.
7. Navigate to http://localhost:5001/swagger. Doing this will bring you to the Swagger UI page. 
8. Expand the _File_ section at the top.
9. Click "Try it out".
10. In the _Request body_ section (the section that lets you enter text), modify the contents so that it looks like the example below:
    ```json
    {
        "fileIds": [
            1000,
            1001,
            1002
        ]
    }
    ```
11. Click _Execute_
12. Assuming that you receive a 200 response back (i.e. success), you will be presented with a _Download file_ link at the bottom; click it.
13. You should now have a `.zip` file containing files for fileIds 1000, 1002, and 1003.

