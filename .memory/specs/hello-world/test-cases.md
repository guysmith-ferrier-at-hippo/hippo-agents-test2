# Test Cases: Hello World Endpoint

## Scenario 1: Successful Greeting Retrieval
- **Type**: Integration
- **Method**: GET
- **Path**: `/hello-world` and `/api/v1/hello-world`
- **Expected Status**: 200 OK
- **Expected Content-Type**: `application/json`
- **Expected Body**: JSON containing `greeting` string equal to `"Hello, World!"`.

## Scenario 2: Unexpected Query Parameters
- **Type**: Integration
- **Method**: GET
- **Path**: `/hello-world?name=Test&locale=es-ES&extra=123`
- **Expected Status**: 200 OK
- **Expected Body**: Static greeting unchanged.

## Scenario 3: Unsupported HTTP Method
- **Type**: Integration
- **Method**: POST
- **Path**: `/hello-world`
- **Expected Status**: 405 Method Not Allowed

## Scenario 4: Health Check Verification
- **Type**: Integration
- **Method**: GET
- **Path**: `/health`
- **Expected Status**: 200 OK
- **Expected Body**: "Healthy"

## Scenario 5: Response Model Serialization
- **Type**: Unit
- **Target**: `GreetingResponse`
- **Assertion**: Correct property values and camelCase JSON serialization.
