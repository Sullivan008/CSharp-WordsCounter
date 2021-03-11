import { ApiExceptionCode } from '../enums/api-exception-code.enum';

const exceptionMessages: { [exceptionCode: number]: string } = {};

export function localizeException(exceptionCode: number): string {
  const exceptionMessage = exceptionMessages[exceptionCode];

  if (exceptionMessage) {
    return exceptionMessage;
  }

  return getBadRequestMessage();
}

export function getBadRequestMessage(): string {
  return 'Unknow error!';
}

export function getInternalServerErrorMessage(): string {
  return 'Internal server error!';
}
