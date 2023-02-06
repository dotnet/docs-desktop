---
title: "Planning for Application Performance"
description: Learn how to plan for application performance optimization and understand how to develop performance strategies for your applications.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "applications [WPF], optimizing"
  - "WPF application [WPF], optimizing"
ms.assetid: c91bd0c5-a193-46ff-9da1-eb7a3a76a3b3
---
# Planning for Application Performance

The success of achieving your performance goals depends on how well you develop your performance strategy. Planning is the first stage in developing any product. This topic describes a few very simple rules for developing a good performance strategy.  
  
## Think in Terms of Scenarios  

 Scenarios can help you focus on the critical components of your application. Scenarios are generally derived from your customers, as well as competitive products. Always study your customers and find out what really makes them excited about your product, and your competitors' products. Your customers' feedback can help you to determine your application's primary scenario. For instance, if you are designing a component that will be used at startup, it is likely that the component will be called only once, when the application starts up. Startup time becomes your key scenario. Other examples of key scenarios could be the desired frame rate for animation sequences, or the maximum working set allowed for the application.  
  
## Define Goals  

 Goals help you to determine whether an application is performing faster or slower. You should define goals for all of your scenarios. All performance goals that you define should be based on your customers' expectations. It may be difficult to set performance goals early on in the application development cycle, when there are still many unresolved issues. However, it is better to set an initial goal and revise it later than not to have a goal at all.  
  
## Understand Your Platform  

 Always maintain the cycle of measuring, investigating, refining/correcting during your application development cycle. From the beginning to the end of the development cycle, you need to measure your application's performance in a reliable, stable environment. You should avoid variability caused by external factors. For example, when testing performance, you should disable anti-virus or any automatic update such as SMS, in order not to impact performance test results. Once you have measured your application's performance, you need to identify the changes that will result in the biggest improvements. Once you have modified your application, start the cycle again.  
  
## Make Performance Tuning an Iterative Process  

 You should know the relative cost of each feature you will use. For example, the use of reflection in Microsoft .NET Framework is generally performance intensive in terms of computing resources, so you would want to use it judiciously. This does not mean to avoid the use of reflection, only that you should be careful to balance the performance requirements of your application with the performance demands of the features you use.  
  
## Build Towards Graphical Richness  

 A key technique for creating a scalable approach towards achieving WPF application performance is to build towards graphical richness and complexity. Always start with using the least performance intensive resources to achieve your scenario goals. Once you achieve these goals, build towards graphic richness by using more performance intensive features, always keeping your scenario goals in mind. Remember, WPF is a very rich platform and provides very rich graphic features. Using performance intensive features without thinking can negatively impact your overall application performance.  
  
 WPF controls are inherently extensible by allowing for wide-spread customization of their appearance, while not altering their control behavior. By taking advantage of styles, data templates, and control templates, you can create and incrementally evolve a customizable user interface (UI) that adapts to your performance requirements.  
  
## See also

- [Optimizing WPF Application Performance](optimizing-wpf-application-performance.md)
- [Taking Advantage of Hardware](optimizing-performance-taking-advantage-of-hardware.md)
- [Layout and Design](optimizing-performance-layout-and-design.md)
- [2D Graphics and Imaging](optimizing-performance-2d-graphics-and-imaging.md)
- [Object Behavior](optimizing-performance-object-behavior.md)
- [Application Resources](optimizing-performance-application-resources.md)
- [Text](optimizing-performance-text.md)
- [Data Binding](optimizing-performance-data-binding.md)
- [Other Performance Recommendations](optimizing-performance-other-recommendations.md)
