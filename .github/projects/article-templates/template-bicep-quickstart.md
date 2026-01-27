---
title: #Required. The page title that's displayed in search results. Start with "Quickstart" and include "Bicep."
description: #Required. The article description that's displayed in search results. Include "quickstart."
author: #Required. Your GitHub user alias. Use correct capitalization.
ms.author: #Required. The Microsoft alias of the author. Optionally, a team alias.
ms.service: #Required. The approved service name. The service slug assigned by ACOM.
ms.topic: quickstart-bicep #Required; leave this attribute/value as-is.
ms.custom: #Required. Use "subject-bicepqs."
ms.date: #Required. The publish date in mm/dd/yyyy format.
---

<!--
Remove all the comments in this template before you sign off or merge to the 
main branch.

This template provides the basic structure of a general troubleshooting article pattern. See the
[instructions - Quickstart - Bicep](../level4/article-bicep-quickstart.md) in the pattern library.

You can provide feedback about this template at: https://aka.ms/patterns-feedback

-->

<!-- 1. H1 -----------------------------------------------------------------------------

Required: Briefly describe what the reader uses Bicep to do in the quickstart:

- Start with "Quickstart:."
- Use a verb like "Create" or "Deploy" immediately after "Quickstart:" that conveys what
the reader does with Bicep in the quickstart.
- Include "Bicep" in the H1.
- Include the product or service that the reader uses Bicep to deploy.

-->

# Quickstart: <create-or-deploy> <product-or-service> with Bicep
TODO: Add your heading

<!-- 2. Introduction -------------------------------------------------------------------

Required: Start with "In this quickstart" in a sentence that mentions what the user does
with Bicep in the quickstart.

As the second paragraph, use the `resource-manager-quickstart-bicep-introduction.md`
include file.

Avoid using the following elements:

- Green check mark lists
- Checklists of subsections
- Lists of learning goals
- Lists of service capabilities
- Callouts
- Screenshots or diagrams that push the prerequisites out of view
- Links, except the link to Bicep information that the include file contains and links
to alternate versions of the same content
- The time it takes to complete the quickstart

-->

[Introductory sentence]
TODO: Add your introductory sentence

[!INCLUDE [About Bicep](<relative-path>/includes/resource-manager-quickstart-bicep-introduction.md)]
TODO: Update the path to the include file

<!-- 3. Prerequisites ------------------------------------------------------------------

Required: List items that are required for the quickstart in this section.

Make this section the first H2 section after the H1.

Begin this section with this sentence: If you don't have an Azure subscription, create a
[free account](https://azure.microsoft.com/free/?WT.mc_id=A261C142F) before you begin.

List any other prerequisites in the order and format that's specified in the
[quickstart template](../level4/global-quickstart-template.md).

Follow the Azure CLI and Azure PowerShell prerequisite guidelines:

- [Azure CLI article guidelines - prerequisites](conventions-azure-cli.md#prerequisites)
- [Azure PowerShell code conventions - prerequisites](conventions-azure-ps.md#prerequisites)

-->

## Prerequisites

- If you don't have an Azure subscription, create a [free account](https://azure.microsoft.com/free/?WT.mc_id=A261C142F) before you begin.
- [Your prerequisites]
  TODO: Add your prerequisites
- [Azure CLI prerequisites]
  TODO: Add the Azure CLI prerequisites
- [Azure PowerShell prerequisites]
  TODO: Add the Azure PowerShell prerequisites

<!-- 4. Review the Bicep file ----------------------------------------------------------

Required: Provide information about Bicep resources in this section.

Start with the following sentence: The Bicep file used in this quickstart is from
[Azure Quickstart Templates](https://azure.microsoft.com/resources/templates/<template-name>).

Add your Bicep file:

- If it's a reasonable length, add a code block that contains the entire file. Use this
  format:

  ```text
  :::code language="bicep" source="~/quickstart-templates/<template-name>/main.bicep":::
  ```

- If your Bicep file contains more than 250 lines, use this sentence instead:

  `The Bicep file for this article is too long to show here. To view the Bicep file, see
  [main.bicep](<link-to-Bicep-file-raw-output>)`.

Provide a list of links to definitions of the resource types that the Bicep file defines.

- List the resource type links in the same order as in the Bicep file.
- Begin each link URL with `/azure/templates`.
- Remove API versions from URLs so that the URLs redirect to the latest versions.

Optionally, provide a link to other Bicep quickstart files for the service. Use the
following format for the link URL:

https://azure.microsoft.com/resources/templates/?resourceType=<product-or-service-type-name>&pageNumber=1&sort=Popular

-->

## Review the Bicep file

The Bicep file used in this quickstart is from
[Azure Quickstart Templates](https://azure.microsoft.com/resources/templates/<template-name>).

[code-block-or-link-to-code]
TODO: Add your code or link

The following Azure resources are defined in the Bicep file:

- [Link to resource definition]
- [Link to resource definition]
- ...

TODO: Add your resource definition links

For more [product or service] Bicep samples, see
[Azure Quickstart Templates by resource types](https://azure.microsoft.com/resources/templates/?resourceType=Microsoft.<product-or-service-type-name>&pageNumber=1&sort=Popular).
TODO: Add your link to samples

<!-- 5. Deploy the Bicep file ----------------------------------------------------------
Required: Explain how to use the Azure CLI and Azure PowerShell to deploy the Bicep file:

- Tell users to save the Bicep file locally with the file name `main.bicep`.
- Provide Azure CLI and Azure PowerShell deployment commands in code blocks. To include
  **Try it** buttons, use `azurecli-interactive` and `azurepowershell-interactive` as
  language indicators.
- If your Azure CLI code block uses the `az deployment group create` command, state that
  it requires Azure CLI version 2.6 or later. Tell readers to enter `az --version` to
  check the version.

--->

## Deploy the Bicep file

1. Save the Bicep file as `main.bicep` to your local computer.

1. Deploy the Bicep file by using either Azure CLI or Azure PowerShell.

   [Azure CLI commands]
   [Azure PowerShell commands]

TODO: Add your commands

<!-- 6. Review deployed resources ------------------------------------------------------
Required: Provide instructions for using Azure CLI or Azure PowerShell commands to
display the deployed resources:

- Give this section an H2 header of *Review deployed resources* or *Validate the
  deployment*.
- Provide Azure CLI and Azure PowerShell commands in code blocks. To include **Try it**
  buttons, use `azurecli-interactive` and `azurepowershell-interactive` as
  language indicators.

--->

## Review deployed resources

[Azure CLI commands]
[Azure PowerShell commands]
TODO: Add your commands

<!-- 7. Clean up resources -------------------------------------------------------------
Required: Explain how to delete unneeded resources.

Consider including the following Azure CLI commands for deleting a resource group:

```azurecli-interactive
echo "Enter the Resource Group name:" &&
read resourceGroupName &&
az group delete --name $resourceGroupName &&
echo "Press [ENTER] to continue ..."
```

Consider including the following Azure PowerShell commands for deleting a resource group:

```azurepowershell-interactive
$resourceGroupName = Read-Host -Prompt "Enter the Resource Group name"
Remove-AzResourceGroup -Name $resourceGroupName
Write-Host "Press [ENTER] to continue..."
```
-->

## Clean up resources

[Instructions for cleaning up resources]
[Azure CLI commands]
[Azure PowerShell commands]
TODO: Add your instructions and commands

<!-- 8. Next steps ---------------------------------------------------------------------

Required: Provide links in this section that lead to related information.

Include a link to the next logical quickstart. Possibilities include:

- The next article for your service.
- A quickstart about creating a Bicep file: [Quickstart: Create Bicep files with Visual
  Studio Code](/azure/azure-resource-manager/bicep/quickstart-create-bicep-use-visual-studio-code).

Use a blue box for the quickstart link by using the following Markdown code:

> [!div class="nextstepaction"]
> [Quickstart: <quickstart-title>](<quickstart-url>)

If you include links to information about the service, use a paragraph or bullet points.

-->

## Next steps

> [!div class="nextstepaction"]
> [Quickstart: <quickstart-title>](<quickstart-url>)

- [Links to related information]
TODO: Add your quickstart or related information links

<!--
Remove all comments in this template before you sign off or merge to the main branch.

-->