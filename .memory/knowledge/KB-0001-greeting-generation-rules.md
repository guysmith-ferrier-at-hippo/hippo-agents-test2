---
id: KB-0001
title: Greeting Generation and Time-of-Day Calculation Rules
component: greeting-service
domain: domain-logic
tags:
- greetings
- time-of-day
- localization
- fallback
status: validated
created: '2026-11-11'
updated: '2026-11-11'
---

# KB-0001: Greeting Generation and Time-of-Day Calculation Rules

## Context
Customer greetings depend on customer name, local time of day, and preferred language locale. The API must calculate time boundaries predictably across diverse client time zones.

## Key Rules
1. **Time of Day Intervals:**
   - **Morning:** 05:00 to 11:59 (local time).
   - **Afternoon:** 12:00 to 16:59 (local time).
   - **Evening:** 17:00 to 21:59 (local time).
   - **Night / General:** 22:00 to 04:59 (local time).
2. **Localization Fallback:**
   - If a requested locale is unsupported (e.g. `de-DE` before German templates are added), the service falls back gracefully to `en-GB`.
3. **Customer Name Formatting:**
   - If a customer name is omitted, generic greetings are rendered (e.g., "Good morning").
   - If a customer name is supplied, the formatted string includes the sanitized customer name (e.g., "Good morning, Jane").

## Applicability
Apply these rules in all greeting endpoint handlers and domain service classes.