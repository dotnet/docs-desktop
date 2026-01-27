---
model: Claude Haiku 4.5 (copilot)
agent: agent
description: "Migrate metadata service from dotnet-framework to dotnet-desktop for article."
---

There are two lifecycles for articles: dotnet-framework and dotnet-desktop:

Articles that are dotnet-desktop should have the `ms.service` metadata set to `dotnet-desktop` and the `ms.update-cycle` set to `365-days`.

Articles that are dotnet-framework should have the `ms.service` metadata set to `dotnet-framework` and the `ms.update-cycle` set to `1825-days`.

Change this article to `dotnet-desktop` and update the metadata accordingly.
