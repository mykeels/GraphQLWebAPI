# GraphQL Web API

A sample starter project for a demo of GraphQL Integration with ASP.NET Web API projects.

### Dependencies

- Newtonsoft.Json
- GraphQL
- GraphQL-Parser

### Endpoints

```
- ~/api/books
- ~/api/books?isbn={isbn}
- ~/api/authors
- ~/api/authors/book?isbn={isbn}
- ~/api/authors?id={authorId}
- ~/api/publishers
- ~/api/publishers?id={publisherId}
- ~/api/publishers/book?isbn={isbn}
```

### Sample Book Data

```json
{
    "Isbn": "c91554b2-6e9b-454a-99a3-4f5506baa843",
    "Name": "A tale of two cities",
    "Author": {
        "Id": 1,
        "Name": "David Peter",
        "Birthdate": "2033-07-08T23:54:07.5182468+01:00",
        "Books": []
    },
    "Publisher": {
        "Id": 1,
        "Name": "Macmillan",
        "Books": [],
        "Authors": []
    }
}
```