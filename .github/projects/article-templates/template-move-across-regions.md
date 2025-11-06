---
title: #Required; page title is displayed in search results. Format is: Relocation guidance for [service-name] 
description: #Required; article description that is displayed in search results. Include the words "relocate", and "region" in the description.
author: #Required; your GitHub user alias, with correct capitalization.
ms.author: #Required; microsoft alias of author; optional team alias.
ms.service: #Required; service per approved list. slug assigned by ACOM.
ms.topic: how-to #Required; leave this attribute/value as-is.
ms.date: #Required; mm/dd/yyyy format.
ms.custom: 
  - subject-moving-resources 
  - subject-relocation #Required; leave this attribute/value as-is.

---

<!--
Remove all the comments in this template before you sign-off or merge to the 
main branch.

This template provides the basic structure of the pattern for an article describing
relocating service resources to a different region. See the 
[relocate across regions pattern](article-move-across-regions.md) article in the
pattern library.

This template provides the basic structure of a Move service resources article pattern. See the
[instructions - Relocate service resources](../level4/article-move-across-regions.md) in the pattern
library.

You can provide feedback about this template at: https://aka.ms/patterns-feedback

1. Customer intent statement -------------------------------------------------------
Required. Add the customer intent statement as a comment in the last line of the
metadata.

-->

#Customer intent: As a < type of user >, I want < what? > so that < why? >.
TODO: Add customer intent statement.

<!-- 2. H1 -----------------------------------------------------------------------------
Required. The article heading should be clear. Must be in format: Relocate [service-name] to another region

-->

# [H1 heading]
TODO: Add your heading.

<!-- 3. Introductory paragraph ----------------------------------------------------------
Required. Describe the article. Here's an example:

This article describes how to relocate [service-name] resources to a different Azure region.
You might move your resources to another region for a number of reasons. For example, to
take advantage of a new Azure region, to deploy features or services available in
specific regions only, to meet internal policy and governance requirements, or in
response to capacity planning requirements.

-->

[Add your introductory paragraph]
TODO: Add your introductory paragraph

<!-- 4. Prerequisites --------------------------------------------------------------------

Required. Prerequisites include anything that must be in place before you start to move
resources to another region.

Entries in this section might be requirements or limitations, checks to make, or steps
to take before the move. 

If there are no prerequisites, state that in this section.

-->

## Prerequisites
TODO: Add the Prerequisites section.

<!-- 5. Prepare -------------------------------------------------------------------------
Required. Describe how to prepare service resources before moving them.

-->


## Considerations for Service Endpoints
TODO: Add the Considerations for Service Endpoints section

<!--  6. Considerations for Service Endpoints -------------------------------------------------------------------------
  
Optional. This section is required if the customer needs to configure new service endpoints in the target region.

-->

## Consideration for Private Endpoints 
TODO: Add the Consideration for Private Endpoints 

<!--  7. Considerations for Private Endpoints -------------------------------------------------------------------------
  
Optional. This section is required if the customer needs to configure new private endpoints in the target region.

-->

## Prepare
TODO: Add the Prepare section.

<!-- 8. Prepare ----------------------------------------------------------------------------
Required. Describe how to prepare service resources to relocate to another region.

-->

## Modify the template
TODO: Add the Modify the template section.

<!-- 9. Modfiy the template ----------------------------------------------------------------------------
Required. Describe how to modify the ARM template for the service resources to relocate to another region.

-->


## Redeploy
TODO: Add the Redeploy section.

<!-- 10. Redeploy with data----------------------------------------------------------------------------
    Optional. Describe how to redeploy service resources with data to another region.
    
    -->
    
## Redeploy with data
TODO: Add the Redeploy section.

<!-- 11. Verify --------------------------------------------------------------------------
Required. Check that resources have been moved, and appear as expected in the target
region.

-->

## Verify
TODO: Add the Verify section.

<!-- 12. Commit --------------------------------------------------------------------------
Optional. Add a description if your service supports a commit action to complete the move
after verification.

-->

## Commit
TODO: Add this section, if necessary.

<!-- 13. Discard target resources --------------------------------------------------------
Optional. Describe how to remove the resources that the customer just moved.

Customers might need these instructions if the move to the target region was a test or
proof-of-concept, or if they no longer need the resources after they've been moved.

-->

## Discard target resources
TODO: Add this section, if desired.

<!-- 14. Clean up resources -------------------------------------------------------------
Required. Describe how to clean up and delete resources that still exist in the
source region.

-->

## Clean up source resources
TODO: Add the Clean up resources section.

<!-- 15. Next steps ---------------------------------------------------------------------
Optional. If there are actions that should be taken now that resources are running in the
new target region, provide links to information about those actions.

-->

## Next steps
TODO: Add your next steps.

<!--
Remove all the comments in this template before you sign-off or merge to the main branch.

-->
