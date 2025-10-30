# AI-Assisted Blazor App Development Guide  
### Authored by: IT Apps Dev Team  

---

## Purpose
This guide explains **how I use AI** to speed up the development of Blazor applications.  
It’s not just about asking AI to “generate code” — it’s about **structuring prompts** so AI understands our architecture and naming conventions.  

By following this guide, you can:
- Maintain consistent repository and folder structure  
- Generate Data Models, Repositories, and UI pages fast  
- Reduce repetitive manual work  
- Focus more on logic and design  

---

## My Prompting Pattern

### 1. **DATA MODEL**
This is where I instruct AI to generate a class representing a table from the database.

**Prompt Example:**
```
Create a data class from table BILL_S_Customer and save to Data folder same with BILL_S_Tariff
```

**How AI interprets it:**
- Create a `.cs` file under the **Data** folder  
- Use `[Table("BILL_S_Customer")]` and `[Column(...)]` attributes  
- Follow naming convention and data annotations (like `[Key]`, `[MaxLength]`)  

**Tip:**  
Always specify which columns to include and the expected folder path.

---

### 2. **INTERFACE AND IMPLEMENTATION**
This pattern creates the repository interface and implementation for data access.

**Prompt Example:**
```
Create an Interface and Implementation class for DCSTariffRate located at Data folder. 
Same with the Tariff, save the interface in "Components/Repository/IRepository", 
and the implementation in "Components/Repository".
```

**How AI interprets it:**
- Generate `IDCSTariffRateRepository.cs` under `IRepository`
- Generate `DCSTariffRateRepository.cs` under `Repository`
- Include CRUD methods (GetAll, GetById, Create, Update, Delete)
- Use `ApplicationDbContext` for data operations

**Tip:**  
Remind AI to inject `ApplicationDbContext` using constructor dependency injection.

---

### 3. **UI COMPONENTS**
Once data and logic layers are ready, I instruct AI to create Blazor components.

**Prompt Example:**
```
Same with Tariff, in the folder "Components/Pages/Tariff_Pages", 
create blazor components TariffRateList and TariffRateUpsert.
```

**How AI interprets it:**
- Generate two `.razor` files:  
  - `TariffRateList.razor` → for listing data  
  - `TariffRateUpsert.razor` → for add/edit operations  
- Include `@inject` repository and call async methods (LoadData, Save, Delete)  
- Bind properties to the data model  

---

### 4. **EASY DEV PATTERN EXAMPLE**
For table `BILL_S_Billable_Services`, using this pattern, ask AI to create:

1. **Data Model**
2. **Repository Interface**
3. **Repository Implementation**
4. **Database Context Integration**
5. **Dependency Injection Registration**
6. **Blazor UI Components (save to Service_Pages folder)**
7. **Navigation Integration**

**Prompt Example:**
```
For table BILL_S_Billable_Services, using my pattern, create the following:
1. Data Model
2. Repository Interface
3. Repository Implementation
4. Database Context Integration
5. Dependency Injection Registration
6. Blazor UI Components (save to Service_Pages folder)
7. Navigation Integration
8. Use this columns for Data Model: [Key]
    [Column("SoftwareTypeID")]
    public int SoftwareTypeId { get; set; }

    [Column("SoftwareTypeName")]
    [MaxLength(255)] 
    public string? SoftwareTypeName { get; set; }

    [Column("IsActive")]
    public bool? IsActive { get; set; }

    [Column("SoftwareTypeDescription")]
    [MaxLength(500)] 
    public string? SoftwareTypeDescription { get; set; }
```

**How AI interprets it:**
- Creates all necessary files and folders automatically
- Uses column definitions to build accurate data models
- Adds repository methods and connects to `ApplicationDbContext`
- Prepares Blazor UI for list and upsert operations
- Adds navigation link for new module

---

## Best Practices
- Use consistent naming for folders and files (`*_Pages`, `IRepository`, etc.)  
- Always verify generated code formatting before committing  
- Leverage AI for repetitive scaffolding, but **review logic manually**  
- Keep prompts short but structured — mention file paths, table names, and target components  

---

## Conclusion
This AI prompt pattern helps maintain clean, repeatable, and scalable Blazor app development.  
It speeds up our workflow, keeps structure consistent, and makes onboarding new developers much easier.

---
