package Common;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

/**
 * Created by Carla on 22/06/2015.
 */
public class Trace {

    private static final Logger logger = LogManager.getLogger("Logger");

    public static void Log(String className, String message,String level,Exception exc ){

        try {

            if (level == "Warning") {
                logger.warn(className + " - " + message);
            } else if (level == "Severe") {
                logger.error(className + " - " + message, exc);
            } else {
                logger.info(className + " - " + message);
            }

        }catch(Exception exception){
            logger.warn(className + " - " + message);
        }
    }
}
