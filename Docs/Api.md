### run project

```
dotnet build
dotnet run --project .\Advice\
```

### Migration

```
dotnet ef migrations add MyFirstMigration
dotnet ef database update
```

#### Create advice for solo travel

```js
POST / soloAdvice;
```

```json
{
  "name": "have a self studying",
  "Place": "starbucks",
  "description": "study alone",
  "tags": ["interesting", "coffee", "studying"]
}
```

```js
201 created
```

#### Get advice

```js
GET /soloAdvice/{{id}}
```

```
200 Ok
```
