# 🧭 Product Vision Document

## 1. Product Overview

**Product Name:**  
Customer Greetings Service API

**Author / Owner:**  
Engineering and Product Team (guysmith-ferrier-at-hippo)

---

## 2. Vision Statement

Provide a reliable and fast service API that generates clear, personalized, and localized customer greetings for digital applications.

---

## 3. Problem Statement

Digital applications must show consistent and friendly greetings to customers.

- **Who experiences the problem?**  
  Client web applications, mobile applications, and internal microservices that communicate with customers.
- **What is the impact of the problem today?**  
  Teams build greeting logic separately in each application. This causes inconsistent tone, duplicate code, and slow updates.
- **Why does solving this matter?**  
  A centralized greetings API ensures brand consistency. It also reduces development time across all client systems.

---

## 4. Target Users / Audiences

| Persona | Description | Key Needs / Goals |
|---|---|---|
| Frontend Developer | Developer of client web and mobile user interfaces. | Simple HTTP endpoints, clear OpenAPI contract, predictable JSON output. |
| Backend Integrator | Engineer connecting downstream services. | Low latency, reliable uptime, and clear error responses. |
| Customer / End User | Person using client digital portals. | Clear, personalized, and culturally respectful greeting messages. |

---

## 5. Product Goals & Outcomes

| Goal | Metric / KPI | Desired Outcome |
|---|---|---|
| Centralize greeting generation | Number of consuming client applications | Multiple applications consume one shared API service. |
| Deliver low latency responses | P95 API response duration | P95 latency is less than 50 milliseconds. |
| Provide clear contract documentation | OpenAPI documentation completeness | 100% of endpoints are fully documented and testable via Swagger UI. |

---

## 6. Key Features / Capabilities

- Personalized greeting generation based on customer name and salutation.
- Contextual greeting generation based on local time of day (morning, afternoon, evening).
- Multi-language greeting support via locale parameters.
- Interactive OpenAPI documentation page for API exploration and testing.
- Health check endpoints for monitoring and deployment readiness.

---

## 7. Value Proposition

| For (user type) | Who want to (need) | Our product (solution) | Unlike (alternative) |
|---|---|---|---|
| Client Applications | Display localized and personalized greetings | Customer Greetings Service API | Hardcoded greeting strings across disparate client applications |
| Software Developers | Integrate greeting messages quickly | An OpenAPI-compliant REST microservice | Custom greeting code written and maintained in each frontend repository |

---

## 8. Constraints / Assumptions

- The service uses the modern .NET 10 runtime and ASP.NET Core Minimal APIs ([ASSUME-0001](assumptions/ASSUME-0001-dotnet-tech-stack.md)).
- Initial greeting templates and rules are stored in memory and application configuration ([ASSUME-0002](assumptions/ASSUME-0002-in-memory-template-storage.md)).
- The API will provide an interactive OpenAPI (Swagger) web interface for developers.
- The service must comply with GDPR by not persisting personal customer data in request logs.

---

## 9. Success Metrics

- **Primary metric:** API availability of 99.9% uptime during operational hours.
- **Secondary metric:** Response latency under 50ms for 95% of incoming requests.
- **Qualitative indicators:** Developer satisfaction with OpenAPI documentation and ease of integration.

---

## 10. Stakeholders

| Role | Name / Team | Interest / Contribution |
|---|---|---|
| Technical Lead | guysmith-ferrier-at-hippo | Architecture design, code reviews, and quality standards. |
| Client Developers | Cross-functional Application Teams | API consumption, contract feedback, and integration testing. |
| Product Owner | Product Management | Functional requirements, greeting templates, and localization requirements. |

---

## 11. Risks & Open Questions

- *Risk:* Time zone discrepancies if client requests do not include a specific client time offset.  
  *Mitigation:* Accept an optional ISO 8601 timestamp or explicit time zone parameter in the request.
- *Open Question:* Will future phases require dynamic greeting template authoring by non-technical staff?  
  *Path:* Validate with product management before commencing the Beta phase.

---

## 12. References

- [ASSUME-0001: Use .NET 10 and ASP.NET Core Minimal APIs](assumptions/ASSUME-0001-dotnet-tech-stack.md)
- [ASSUME-0002: In-Memory and Configuration Greeting Template Storage for Alpha](assumptions/ASSUME-0002-in-memory-template-storage.md)
- OpenAPI Specification 3.0 Standard

## 13. Value Rule Set

> _The criteria or rules used to evaluate whether features should proceed to development._

| Rule / Criterion | Description | Minimum Threshold for Go |
|------------------|-------------|--------------------------|
| Developer Productivity | Reduces integration time for client apps. | High |
| Brand Consistency | Ensures standardized greetings across platforms. | High |
| System Reliability | Maintains fast response times and API uptime. | Pass |
