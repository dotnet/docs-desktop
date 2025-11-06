---
title: Use managed identities in [Service name] | Microsoft Docs #Required; page title is displayed in search results. 
description: Learn how to use managed identities with [Service name] using the Azure portal, CLI, PowerShell, and ARM template. #Required; article description that is displayed in search results. Update depending on which options you use.
author: #Required; your GitHub user alias, with correct capitalization.
ms.author: #Required; microsoft alias of author; optional team alias.
ms.service: #Required; Select service from approved list.
ms.topic: how-to #Required.
ms.date: #Required; mm/dd/yyyy format.
---

<!--
Remove all the comments in this template before you sign-off or merge to the main branch.

This template provides the basic structure of a Managed identities article pattern. See the
[instructions - Managed identities](../level4/article-managed-identities.md) in the pattern library.

You can provide feedback about this template at: https://aka.ms/patterns-feedback

1. H1 ------------------------------------------------------------------------------
Required. Use this wording:

-->
# How to use managed identities with [Service name]
TODO: Add H1 headline.

<!-- 2. Introduction --------------------------------------------------------------------
Required. Briefly introduce using managed identities with your service.

-->

This article shows you how to use managed identities with a [Service name] instance.
TODO: Add introduction.

<!-- 3. H2 Prerequisites ----------------------------------------------------------------
Optional. If needed, make this your first H2.

-->

## Prerequisites

- [Prerequisite 1]
- [Prerequisite 2]
- [Prerequisite n]

TODO: Add prerequisites section, if needed.

<!-- 4. Create an instance --------------------------------------------------------------
Required. Show the steps required to create an instance of your service with a system
assigned managed identity enabled using as many of the options shown below as possible.
You can see additional tab options: 
https://review.learn.microsoft.com/help/platform/validation-ref/tabbed-conceptual

-->

## Create an instance of [service name] with a system assigned managed identity

# [Portal](#tab/azure-portal)

# [Azure PowerShell](#tab/azure-powershell)

# [Azure CLI](#tab/azure-cli)

# [ARM template](#tab/azure-resource-manager)

---

TODO: Add Create an instance section with tabbed conceptual options.

<!-- 5. Assign identity -----------------------------------------------------------------
Required. Show the steps required to create an instance of your service using a
user-assigned managed identity. Use as many of the options shown below as possible.

-->

## Assign a user-assigned managed identity to a service instance

# [Portal](#tab/azure-portal)

# [Azure PowerShell](#tab/azure-powershell)

# [Azure CLI](#tab/azure-cli)

# [ARM template](#tab/azure-resource-manager)

---

TODO: Add Assign identity section with tabbed conceptual options.

<!-- 6. Support scenarios --------------------------------------------------------------- 
Required. Describe managed identity scenarios for users and system.

If there are differences between the support available for user assigned managed
identities versus system assigned managed identities, call that out here.

-->

## Supported scenarios using managed identities

### User assigned managed identities

### System assigned managed identities

TODO: Describe supported scenarios.

<!-- 7. Grant access to managed identities ----------------------------------------------
Required. If customers need to grant access to managed identities so they may interact
with data hosted by your service include the steps here. 

We recommend that you follow the Azure RBAC guidance to grant the managed identities the
necessary permissions to access the resource because then you do not need to worry about
maintaining these steps as part of your documentation. Some examples are shown here.

-->

### Grant access to a managed identity
TODO: Add grant access section.

<!-- Examples

Example 1:

Using managed identities for Azure resources, your code can access tokens that enable
you to authenticate to resources that support Azure AD authentication. [Service name]
supports Azure AD authentication. Grant the managed identity access by assigning the
[appropriate role](../role-based-access-control/built-in-roles.md) to the managed
identity at the scope of the resource group that contains your [resource instance].
 
For detailed steps, see
[Assign Azure roles using the Azure portal](../role-based-access-control/role-assignments-portal.md).

Example 2:

## Grant your VMs system-assigned managed identity access to use a storage SAS

Azure Storage does not natively support Azure AD authentication.  However, you can use
your VM's system-assigned managed identity to retrieve a storage SAS from Resource
Manager, then use the SAS to access storage.  In this step, you grant your VMs 
system-assigned managed identity access to your storage account SAS. Grant access by
assigning the [Storage Account Contributor](../role-based-access-control/built-in-roles.md#storage-account-contributor)
role to the managed-identity at the scope of the resource group that contains your
storage account.
 
For detailed steps, see
[Assign Azure roles using the Azure portal](../role-based-access-control/role-assignments-portal.md).

>[!NOTE]
> For more information on the various roles that you can use to grant permissions to 
> storage review [Authorize access to blobs and queues using Azure Active Directory](../../storage/common/storage-auth-aad.md#assign-azure-roles-for-access-rights).

-->

<!-- 8. Clean up ------------------------------------------------------------------------
Required. Include the steps that customers should follow to clean up their environment.

-->

## Clean up steps
TODO: Add clean up steps.

<!-- 9. Next steps ----------------------------------------------------------------------
Required. Add links to articles related to the service or managed identities.

-->

## Next steps

Learn more about managed identities for Azure resources:

- [What are managed identities for Azure resources?](https://docs.microsoft.com/azure/active-directory/managed-identities-azure-resources/overview)

TODO: Add Next steps.

<!--
Remove all the comments in this template before you sign-off or merge to the main branch.

-->
