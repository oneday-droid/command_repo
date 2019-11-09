<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
							  xmlns:xs="http://www.w3.org/2001/XMLSchema"
							  exclude-result-prefixes="xs">
    <xsl:output method="html" encoding="UTF-8" indent="yes" media-type="text/html"/>
        
    <xsl:template match="main">
		<HTML>            
        <head>
            <meta charset="utf-8"/>
            <div style="font-family:Arial;font-size:24pt;background-color:#FFFFFF;font-weight:bold" align="center" valign="center">Результаты запроса</div>
				<!--style>
					body
					{
						font-family: Arial;
						font-size: 14pt;
						background-color: #FFFFFF;
						zoom: 0.5;
					}
				</style-->
        </head>
          
        <body>
			    <div>  
					  Таблица: <xsl:value-of select="table/@name"/> <br/><br/>
          <table border="1" align="center">
              <xsl:for-each select="table/row">
                <tr>
                  <xsl:for-each select="column">
                    <td align="left" valign="center" style="width:300px;height:20px;">
                        <xsl:value-of select="/"/>  
                    </td>
                  </xsl:for-each>
                </tr>
              </xsl:for-each>						  
					  </table>
				  </div>
        </body>
      
		</HTML>
    </xsl:template>
</xsl:stylesheet>