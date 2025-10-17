---
title: #Required; page title displayed in search results. You can use the H1 headline, described below. Keep in mind the 65 char or less length suggestion.
description: #Required; article description that is displayed in search results. Use the word quickstart, as in "Quickstart:"
author: #Required; your GitHub user alias, with correct capitalization.
ms.author: #Required; microsoft alias of author; optional team alias.
ms.service: #Required; service per approved list. service slug assigned to your service by ACOM.
ms.topic: quickstart-sdk #Required; leave this attribute/value as-is.
ms.date: #Required; mm/dd/yyyy format.
---

<!--
Remove all the comments in this template before you sign-off or merge to the 
main branch.

This template provides the basic structure of a Quickstart - SDK article pattern. See the
[instructions - Quickstart - SDK](../level4/article-sdk-quickstart.md) in the pattern library.

You can provide feedback about this template at: https://aka.ms/patterns-feedback

A client library SDK Quickstart helps a developer get up and running quickly with the
library. Its primary goal is to help the developer install the library's package and
perform several key coding tasks in their chosen development environment. 

-->

<!-- 1. H1 ------------------------------------------------------------------------------
Required. The H1 of your Quickstart should be in this format: 

# Quickstart: [Product Name] client library for [Language]

For example: # Quickstart: Azure Batch client library for Python

-->

# Quickstart: [Product Name] client library for [Language]
TODO: Add your heading.

<!-- 2. Introduction --------------------------------------------------------------------
Required.

The introduction appears directly under the title (H1) of your Quickstart. Describe what
the reader does in the article. The following sentence structures are designed to
maximize SEO:

- First sentence: "Get started with the [service/product] client library for [language]
  to [achieve specific goals]."

  Describe what the quickstart demonstrates with the service. 

  For example: "Get started with the Computer Vision client library for Python to analyze
  a variety of visual features and to recognize printed and handwritten text."

- Subsequent sentence: "Follow these steps to install the package and try out example
  code for basic tasks."

Include the following single line of links at the bottom of the introduction:

"API reference documentation | Library source code | Package (PyPi) | Samples"

Adjust as necessary, for example, NuGet instead of PyPi.

- Avoid other links in the introduction.
- If there is an important callout that applies to the article, you might include it
  after the line of links. If possible, place it later in the article.

-->

[Your introduction]
TODO: Add your introduction.

[Link line]
TODO: Add line of links at the end of the introduction.

<!-- 3. H2 Prerequisites section --------------------------------------------------------
Required. List the prerequisites as items, not actions. Installing the library is a step,
not a prerequisite.

For example:

* An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/free/?WT.mc_id=A261C142F).
* [Python 3.6+](https://www.python.org/downloads/)

Note: Use the exact phrase above for Azure.

For installers or runtime versions, link to a specific downloads page rather than an
informational page. For instance, link to `https://www.python.org/downloads/` rather than
just `https://www.python.org/`.

-->

## Prerequisites
TODO: List prerequisites.

<!-- 4. Setting up ----------------------------------------------------------------------
Required. Walk the reader through preparing their environment for working with the
client library.

- Include instructions for creating the Azure resources required to make calls to the
  service, obtain credentials, and set up a local development environment.
- Include instructions for obtaining credentials and other requirements, like an endpoint
  URI, needed to instantiate an authenticated client object.
- If you provide console-based instructions, include examples formatted for execution in Windows, macOS, and Linux consoles.
For Windows, format for PowerShell (it's the most popular shell among users of Azure documentation). For macOS and Linux, format for Bash. Lead with PowerShell, then Bash.
- Use Azure portal screenshots sparingly, and only if necessary.
- 
-->

## Setting up
TODO: Add Setting up section.

<!-- 5. Install the package H3 section --------------------------------------------------
Required. Provide instruction for obtaining and installing the library's package. 

-->

### Install the package
TODO: Add this install section.

<!-- 6. Object model --------------------------------------------------------------------
Required. Introduce and describe the functionality of the library's main classes. Include
links to their reference pages.

Explain the object hierarchy and how the classes work together to manipulate resources
in the service.

-->

## Object model
TODO: Add object model section.

<!-- 7. Code examples -------------------------------------------------------------------
Required. Code snippets and short descriptions for each task you listed in the
introduction.

If available, present the same example snippets that the library's README contains.

Present each example as an H3 section that describes the example. At the top of this
section, just under the *Examples* H2, add a bulleted list that links to each example H3.

For example: 

- [Authenticate the client](#authenticate-the-client)
- [Create the thing](#create-the-thing)
- [Get the thing](#get-the-thing)
- [List the things](#list-the-things)

If your library requires client authentication, start with this example section:

### Authenticate the client

Include your other code examples, for instance:

### Create the thing
### Get the thing
### List the things

-->

## Code examples
TODO: Add bulleted list of links to H3 examples.

TODO: If client authentication is required, add "Authenticate the client" example.

TODO: Add other examples as H3 sections.

<!-- 8. Run the code --------------------------------------------------------------------
Required: Provide instruction for running the script or application. Include the expected
output.

-->

## Run the code
TODO: Add instructions to run the example.

<!-- 9. ## Clean up resources 
Optional: If the developer created resource group, provide instruction to delete it.
If there were any other resources created, provide instruction for deleting those.

-->

## Clean up resources
TODO: Add clean up section.

<!-- 10. ## Troubleshooting -------------------------------------------------------------
Optional:  If you're aware that people commonly run into trouble, help them resolve those
issues in this section.

- Describe common errors and exceptions. Help unpack them if necessary. Include guidance
  for graceful handling and recovery.
- Provide information to help developers avoid throttling or other service-enforced
  errors. For example, provide guidance and examples for using retry or connection
  policies if the library supports it.
- If the client library or a related library supports it, include tips for logging or
  enabling instrumentation to help debug code.

-->

## Troubleshooting
TODO: Add troubleshooting section.

<!-- 11. ## Next steps ------------------------------------------------------------------
Required: Provide a link to the next step for a developer, for instance, a tutorial. 

- Summarize the tasks the developer completed in this Quickstart.
- Provide a button for a suggested next step.
 
Use the `[!div class="nextstepaction"]` extension.

> [!div class="nextstepaction"]
> [Link text](link)


-->
## Next steps
TODO: Add summary and button.

<!--
Remove all the comments in this template before you sign-off or merge to the main branch.

-->
