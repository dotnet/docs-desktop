---
title: Create a {service name} by using Azure Resource Manager template (ARM template)
description: Learn how to create an Azure {service name} by using Azure Resource Manager template (ARM template).
services: azure-resource-manager
ms.service: azure-resource-manager
author: your-github-account-name
ms.author: your-microsoft-alias
ms.topic: quickstart-arm #Required; leave this attribute/value as-is.
ms.custom: subject-armqs
ms.date: MM/DD/YYYY

# Customer intent: As a cloud administrator, I want a quick method to deploy an Azure resource for production environments or to evaluate the service's functionality.
---

<!--
Delete all the comments in this template before you commit changes and publish the article.

For more details and code samples for an ARM quickstart, see the contributor guide article: Write an
ARM template quickstart.

This template provides the basic structure of a Quickstart - Azure Resource Manager article pattern.
See the
[instructions - Quickstart - Azure Resource Manager](../level4/article-resource-manager-quickstart.md)
in the pattern library.

You can provide feedback about this template at: https://aka.ms/patterns-feedback

The H1 must begin with Quickstart: and include the words ARM template. -->

# Quickstart: The H1 heading must include the words ARM template

<!-- First paragraph: Include a sentence that uses Azure Resource Manager template (ARM template)
for the first occurrence about the template. For example:

-->

This quickstart describes how to use an Azure Resource Manager template (ARM template) to create
{service name}.

<!-- Second paragraph: Use the following include file. The include file adds a paragraph that
introduces ARM concepts and includes links to ARM content. You might need to change the path of the
include file depending on your content structure.

-->

[!INCLUDE [About Azure Resource Manager](../../includes/resource-manager-quickstart-introduction.md)]

<!-- Final paragraph: Explains that readers who are experienced with ARM templates can continue to
the deployment. For information about the Deploy to Azure image and how to create the template's
URL, see the contributor guide article Write an ARM template quickstart in the Deploy the template
section.

-->

If your environment meets the prerequisites and you're familiar with using ARM templates, select the
**Deploy to Azure** button. The template will open in the Azure portal.

:::image type="content" source="~/articles/reusable-content/ce-skilling/azure/media/template-deployments/deploy-to-azure-button.svg" alt-text="Button to deploy the Resource Manager template to Azure." border="false" link="https://portal.azure.com/#create/Microsoft.Template/uri/<encoded template URL>":::

## Prerequisites

<!-- This section must begin with a sentence that includes a link to create a free Azure account. If
your service has other prerequisites, list them after the free account sentence.

-->

If you don't have an Azure subscription, create a [free account](https://azure.microsoft.com/free/?WT.mc_id=A261C142F) before you begin.

## Review the template

<!-- The first sentence must be the following sentence. Use a link to the quickstart gallery that
begins with https://azure.microsoft.com/resources/templates/.

-->

The template used in this quickstart is from [Azure Quickstart Templates](https://azure.microsoft.com/resources/templates/<templateName>).

<!--
After the first sentence, add a JSON code sample that links to the quickstart template.
-->

:::code language="json" source="~/quickstart-templates/<TEMPLATE NAME>/azuredeploy.json":::

<!-- After the JSON code fence, add a list of each resource type from the JSON template. List the
resourceType links in the same order as in the template.

-->

- [Azure resource type](link to the template reference): resource type description.
- [Azure resource type](link to the template reference): resource type description.

<!--
For example:

- [Microsoft.KeyVault/vaults](/azure/templates/microsoft.keyvault/vaults): Create an Azure key vault.
- [Microsoft.KeyVault/vaults/secrets](/azure/templates/microsoft.keyvault/vaults/secrets): Create an Azure key vault secret.

-->

<!--
Optional:

List additional quickstart templates. For example:
[Azure Quickstart Templates](https://azure.microsoft.com/resources/templates/?resourceType=Microsoft.Keyvault&pageNumber=1&sort=Popular).

Notice the resourceType and sort elements in the URL.

-->

## Deploy the template

<!--
For more information, see the contributor guide article: Write an ARM template quickstart.

-->

Provide an example of at least one deployment method: Azure CLI, Azure PowerShell, or Azure portal.

## Review deployed resources

<!-- This heading must be titled "Review deployed resources" or "Validate the deployment". -->

Provide an example of at least one method to review deployed resources. Use a portal screenshot of
the resources, Azure CLI commands, or Azure PowerShell commands.

## Clean up resources

<!-- Include a paragraph that explains how to delete unneeded resources. Use the Azure portal, Azure
CLI, or Azure PowerShell.

For more information, see the contributor guide article: Write an ARM template quickstart.

-->

When no longer needed, delete the resource group. The resource group and all the resources in the
resource group are deleted.

## Next steps

<!-- Make the next steps similar to other quickstarts and use a blue button to link to the next
article for your service. Or direct readers to the article: "Tutorial: Create and deploy your first
ARM template" to follow the process of creating a template.

To include additional links for more information about the service, it's acceptable to use a
paragraph and bullet points.

-->

For a step-by-step tutorial that guides you through the process of creating a template, see:

> [!div class="nextstepaction"]
> [Tutorial: Create and deploy your first ARM template](/azure/azure-resource-manager/templates/template-tutorial-create-first-template)
