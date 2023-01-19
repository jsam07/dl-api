# JSONReplacer WebAPI

## 1. Requirements

Before proceeding, ensure you have the following installed:

- .NET 7

## 2. Download starter and build project & dependencies

Clone this repository:

```
git clone git@github.com:jsam07/dl-api.git
```

Build project & dependencies:

```
cd dl-api
dotnet build
``` 

## 3. Start WebAPI

```
cd JSONReplacerWebAPI
dotnet run
```

The server should now be running on [`http://localhost:5217/api/jsonreplacer`](http://localhost:5217/api/jsonreplacer). Replace `5217` with the correct port, if different.

## 4. Using the REST API

You can access the REST API of the server using the following endpoints:

### `GET`

-   `/api/jsonreplacer`: Default API welcome message

### `POST`

-   `/api/jsonreplacer`: Replace all **exact** occurrences of `"dog"` with `"cat"`
    -   Body: `any` (required): Any arbitrary payload

To replace all occurrences of `dog` with `cat` instead (ignoring the quotations), replace line `32` of `./JSONReplacerWebAPI/Controllers/JSONReplacerController.cs` with:
```cs
string payloadReplaced = JsonReplacer.Replace(payloadStr, "dog", "cat");
```


## 5. Testing
 To run the test suite, run the following command from the root folder:
```
dotnet test
```

## 6. Roadmap

-   [ ] Extract `old` and `replacement` from request body to allow for arbitrary replacements. 
-   [ ] Add front-end component to allow users to create and edit JSON payloads directly, instead of using `Postman` (or similar).