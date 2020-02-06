/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Retrieves the content and settings of a message template for messages that are sent
    /// through the SMS channel.
    /// </summary>
    [Cmdlet("Get", "PINSmsTemplate")]
    [OutputType("Amazon.Pinpoint.Model.SMSTemplateResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint GetSmsTemplate API operation.", Operation = new[] {"GetSmsTemplate"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.GetSmsTemplateResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.SMSTemplateResponse or Amazon.Pinpoint.Model.GetSmsTemplateResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.SMSTemplateResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.GetSmsTemplateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetPINSmsTemplateCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        #region Parameter TemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the message template. A template name must start with an alphanumeric
        /// character and can contain a maximum of 128 characters. The characters can be alphanumeric
        /// characters, underscores (_), or hyphens (-). Template names are case sensitive.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TemplateName { get; set; }
        #endregion
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the version of the message template to update, retrieve
        /// information about, or delete. To retrieve identifiers and other information for all
        /// the versions of a template, use the <link linkend="templates-template-name-template-type-versions">Template
        /// Versions</link> resource.</para><para>If specified, this value must match the identifier for an existing template version.
        /// If specified for an update operation, this value must match the identifier for the
        /// latest existing version of the template. This restriction helps ensure that race conditions
        /// don't occur.</para><para>If you don't specify a value for this parameter, Amazon Pinpoint does the following:</para><ul><li><para>For a get operation, retrieves information about the active version of the template.</para></li><li><para>For an update operation, saves the updates to (overwrites) the latest existing version
        /// of the template, if the create-new-version parameter isn't used or is set to false.</para></li><li><para>For a delete operation, deletes the template, including all versions of the template.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SMSTemplateResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.GetSmsTemplateResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.GetSmsTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SMSTemplateResponse";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TemplateName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TemplateName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TemplateName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.GetSmsTemplateResponse, GetPINSmsTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TemplateName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.TemplateName = this.TemplateName;
            #if MODULAR
            if (this.TemplateName == null && ParameterWasBound(nameof(this.TemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Version = this.Version;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Pinpoint.Model.GetSmsTemplateRequest();
            
            if (cmdletContext.TemplateName != null)
            {
                request.TemplateName = cmdletContext.TemplateName;
            }
            if (cmdletContext.Version != null)
            {
                request.Version = cmdletContext.Version;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Pinpoint.Model.GetSmsTemplateResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.GetSmsTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "GetSmsTemplate");
            try
            {
                #if DESKTOP
                return client.GetSmsTemplate(request);
                #elif CORECLR
                return client.GetSmsTemplateAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String TemplateName { get; set; }
            public System.String Version { get; set; }
            public System.Func<Amazon.Pinpoint.Model.GetSmsTemplateResponse, GetPINSmsTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SMSTemplateResponse;
        }
        
    }
}
