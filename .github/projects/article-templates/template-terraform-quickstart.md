---
title: #Required; page title displayed in search results. Start with a verb and include the terms "Azure" and "Terraform". Keep in mind the 65 char or less length suggestion.
description:  #Required; article description that is displayed in search results.
author: #Required; your GitHub user alias, with correct capitalization.
ms.author: #Required; microsoft alias of author; optional team alias.
ms.service: #Required. The approved service name. The service slug assigned by ACOM.
ms.topic: #required; how-to, quickstart, tutorial, as appropriate.
ms.custom: devx-track-terraform #Required
ms.date: #Required; mm/dd/yyyy format.
content_well_notification: 
  - AI-contribution
---

<!--
Remove all the comments in this template before you sign off or merge to the 
main branch.

This template provides the basic structure of a general troubleshooting article pattern. See the
[instructions - Quickstart - Bicep](../level4/article-bicep-quickstart.md) in the pattern library.

You can provide feedback about this template at: https://aka.ms/patterns-feedback

-->

<!-- 1. H1 -----------------------------------------------------------------------------

Required: Briefly describe what the reader uses Terraform to do in the quickstart:

- Start with "Quickstart:."
- Use a verb like "Create" or "Deploy" immediately after "Quickstart:" that conveys what
the reader does with Bicep in the quickstart.
- Include "Terraform" in the H1.
- Include the product or service that the reader uses Terraform to deploy.

-->
TODO: Add H1.

<!-- 2. Introduction -------------------------------------------------------------------
-->

[Introductory sentence]
TODO: Add your introductory sentence/paragraph.

[!INCLUDE [About Terraform](~/azure-dev-docs-pr/articles/terraform/includes/abstract.md)]
TODO: Update the path as needed.

In this article, you learn how to:

<!-- 3. Terraform resource creation list ------------------------------------------------------------------
Required: Add a bullet for each Terraform resource that is used with a link to the reference article. The following is an example format and should be the first bullet:
-->

> [!div class="checklist"]
> * Create a random value (to be used in the resource group name) using [random_pet](https://registry.terraform.io/providers/hashicorp/random/latest/docs/resources/pet)
TODO: Add a bullet for each Terraform resource that is used with a link to the reference article.

<!-- 4. Prerequisites ------------------------------------------------------------------

Required: List items that are required for the quickstart in this section.
Note: The "quickstart-configure" includes the Azure subscription prerequisite. 
You need add only the prerequisites that are specific to your article.
-->

## Prerequisites

- [Install and configure Terraform](/azure/developer/terraform/quickstart-configure)
TODO: Update the path as needed.

<!-- 5. Implement the Terraform code ------------------------------------------------------------------

Required: Include the code sample from the Terraform sample GitHub repo.

All Terraform quickstarts have the following files at a minimum:
- providers.tf
- main.tf
- variables.tf
- outputs.tf

Optionally, there are two other files:
- ssh.tf
- sp.tf
-->

## Implement the Terraform code

> [!NOTE]
> The sample code for this article is located in the [Azure Terraform GitHub repo](https://github.com/Azure/terraform/tree/master/quickstart/201-azfw-with-avzones). You can view the log file containing the [test results from current and previous versions of Terraform](https://github.com/Azure/terraform/tree/master/quickstart/201-azfw-with-avzones/TestRecord.md).
>
> See more [articles and sample code showing how to use Terraform to manage Azure resources](/azure/terraform)
TODO: Update the paths to your sample directory.

1. Create a directory in which to test the sample Terraform code and make it the current directory.

1. Create a file named `providers.tf` and insert the following code:

    :::code language="Terraform" source="~/terraform_samples/quickstart/201-azfw-with-avzones/providers.tf":::
    TODO: Update the path to your sample directory.

1. Create a file named `main.tf` and insert the following code:

    :::code language="Terraform" source="~/terraform_samples/quickstart/201-azfw-with-avzones/main.tf":::
    TODO: Update the path to your sample directory.

1. Create a file named `variables.tf` and insert the following code:

    :::code language="Terraform" source="~/terraform_samples/quickstart/201-azfw-with-avzones/variables.tf":::
    TODO: Update the path to your sample directory.

1. Create a file named `outputs.tf` and insert the following code:

    :::code language="Terraform" source="~/terraform_samples/quickstart/201-azfw-with-avzones/outputs.tf":::
    TODO: Update the path to your sample directory.

<!-- 6. Initialize Terraform ------------------------------------------------------------------
Required. A global file is included to tell the reader how to initialize Terraform.
-->

## Initialize Terraform

[!INCLUDE [terraform-init.md](~/azure-dev-docs-pr/articles/terraform/includes/terraform-init.md)]
TODO: Update the path to the include file.

<!-- 7. Create a Terraform execution plan ------------------------------------------------------------------
Required. A global file is included to tell the reader how to create a Terraform execution plan.
-->

## Create a Terraform execution plan

[!INCLUDE [terraform-plan.md](~/azure-dev-docs-pr/articles/terraform/includes/terraform-plan.md)]
TODO: Update the path to the include file.

<!-- 8. Apply a Terraform execution plan ------------------------------------------------------------------
Required. A global file is included to tell the reader how to create a Terraform execution plan.
-->

## Apply a Terraform execution plan

[!INCLUDE [terraform-apply-plan.md](~/azure-dev-docs-pr/articles/terraform/includes/terraform-apply-plan.md)]
TODO: Update the path to the include file.

<!-- 9. Verify the results ------------------------------------------------------------------
Required. Tell the reader how to use Azure CLI and/or Azure PowerShell to display the main
Azure resource that was created/deployed. 

- Not every Azure service has both a Azure CLI and Azure PowerShell command to display the
main resource. In those cases, use what's available. 
- If you have both commands, use tabs. 
- Use variables obtained from the 'terraform output' call.
- If possible, do not require the reader to copy/paste or manually enter information.
-->

## Verify the results

#### [Azure CLI](#tab/azure-cli)

1. Get the Azure resource group name.

    ```console
    resource_group_name=$(terraform output -raw resource_group_name)
    ```

TODO: Almost every case calls for using the resource group name variable and another 
variable to display the main Azure resource created. Add the commands using the 
following format to set the local environment variable.

1. Run [az group show](/cli/azure/group#az-group-show) to display the resource group.

    ```azurecli
    az group show --name $resource_group_name
    ```

TODO: Update the instructions, link, and command for your Azure resource.
Remember to use line continuation characters - \ for Azure CLI - to
improve readability if the command contains more than one parameter.

#### [Azure PowerShell](#tab/azure-powershell)

1. Get the Azure resource group name.

    ```console
    $resource_group_name=$(terraform output -raw resource_group_name)
    ```

TODO: Update the instructions, link, and command for your Azure resource.
Remember to use line continuation characters - ` for Azure PowerShell - to
improve readability if the command contains more than one parameter.

1. Run [Get-AzResourceGroup](/powershell/module/az.resources/Get-AzResourceGroup) to display the resource group.

    ```azurepowershell
    Get-AzResourceGroup -Name $resource_group_name
    ```

TODO: Update the instructions, link, and command for your Azure resource.

---


<!-- 10. Clean up resources section -----------------------------------------------------
Required. Describe how to reverse what the customer did in the article. 

In most cases, you need only include the file that shows the customer how to 
destroy the resources created previously.

However, in some more advanced cases, you might have the customer do more steps prior 
to implementing the code.

An example is the article to create a VMSS from a Packer image.

In that example, the customer creates the image, then implements and runs the code.

In situations like that, you include the same file as shown below and add the extra 
steps required to reverse any actions the customer did in creating Azure resources.

See the following example where H3 sections are used to separate each cleanup step:

https://docs.microsoft.com/azure/developer/terraform/create-vm-scaleset-network-disks-using-packer-hcl#8-clean-up-resources

-->

## Clean up resources
[!INCLUDE [terraform-plan-destroy.md](includes/terraform-plan-destroy.md)]
TODO: Update the path to the include file.

<!-- 11. Troubleshoot Terraform on Azure section ----------------------------------------
Required. This step should NOT be numbered.
-->

## Troubleshoot Terraform on Azure
[Troubleshoot common problems when using Terraform on Azure](troubleshoot.md)
TODO: Update the path to the include file.

<!-- 12. Next steps section -------------------------------------------------------------
Required. Add only one URL.

If there is no logical next article, link to the Terraform home page, as shown here, or 
you can link to the home page for the Azure service being documented in your article.

-->

## Next steps

> [!div class="nextstepaction"] 
> [Learn more about using Terraform in Azure](/azure/terraform)

TODO: Add section.

<!-- Remove all HTML comments when you're done. -->