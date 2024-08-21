# Domain Models

## Menu
```csharp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner)
    void RemoveDinner(Dinner dinner)
    void UpdateSection(MenuSection section)
    

}    

```

```json
{
  "id": "",
  "name": "menu weno",
  "description": "tortilla papas y salmorejo",
  "averageRating": 4,
  "sections": [
    {
      "id": "",
      "name": "entrantes",
      "description": "abrir boca",
      "items": [
        {
          "id": "",
          "name": "alcaparrones",
          "description": "alcaparrones encurtidos",
          "price": 5.99
        }
      ]
    }
  ],
  "createdAtDatetime": "",
  "updatedAtDatetime": "",
  "hostId": "",
  "dinnerIds": [
    "",
    ""
  ],
  "menuReviewIds": [
    "",
    ""
  ]
}
```